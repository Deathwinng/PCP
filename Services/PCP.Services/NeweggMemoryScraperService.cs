namespace PCP.Services
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using AngleSharp;
    using Microsoft.Extensions.Logging;
    using PCP.Data.Common.Repositories;
    using PCP.Data.Models;
    using PCP.Data.Models.Memory;

    public class NeweggMemoryScraperService : NeweggProductScrapperBaseService, INeweggMemoryScraperService
    {
        private readonly ILogger<NeweggMemoryScraperService> logger;
        private readonly IDeletableEntityRepository<Memory> memoryRepo;
        private readonly IDeletableEntityRepository<Brand> brandRepo;
        private readonly IDeletableEntityRepository<Series> seriesRepo;
        private readonly IDeletableEntityRepository<MemoryType> memoryTypeRepo;
        private readonly IDeletableEntityRepository<MemorySpeed> memorySpeedRepo;

        public NeweggMemoryScraperService(
            ILogger<NeweggMemoryScraperService> logger,
            IDeletableEntityRepository<Memory> memoryRepo,
            IDeletableEntityRepository<Brand> brandRepo,
            IDeletableEntityRepository<Series> seriesRepo,
            IDeletableEntityRepository<MemoryType> memoryTypeRepo,
            IDeletableEntityRepository<MemorySpeed> memorySpeedRepo)
            : base()
        {
            this.logger = logger;
            this.memoryRepo = memoryRepo;
            this.brandRepo = brandRepo;
            this.seriesRepo = seriesRepo;
            this.memoryTypeRepo = memoryTypeRepo;
            this.memorySpeedRepo = memorySpeedRepo;
        }

        public async Task ScrapeMemoryFromProductPageAsync(string productUrl)
        {
            if (productUrl.Contains("Combo"))
            {
                this.logger.LogWarning("Invalid Product.");
                return;
            }

            var document = await this.Context.OpenAsync(productUrl);
            var memoryDataTableRows = this.GetAllTablesRows(document);
            var memoryDataTables = this.GetAllTables(document);
            var memory = new Memory
            {
                Price = this.GetPrice(document),
                ImageUrl = this.GetImageUrl(document),
                Category = this.GetCategoryFromUrl(productUrl),
            };

            this.logger.LogInformation(productUrl);

            foreach (var tableRow in memoryDataTableRows)
            {
                var rowName = tableRow.FirstChild.TextContent.Trim();
                var rowValue = tableRow.LastChild.TextContent.Trim();

                switch (rowName)
                {
                    case "Model":
                        if (this.memoryRepo.AllAsNoTracking().Any(x => x.Model == rowValue))
                        {
                            this.logger.LogWarning("Already exists.");
                            return;
                        }

                        memory.Model = rowValue;
                        break;
                    case "Brand":
                        var brand = this.brandRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (brand == null)
                        {
                            brand = new Brand
                            {
                                Name = rowValue,
                            };
                        }

                        memory.Brand = brand;
                        break;
                    case "Series":
                        var seriesName = rowValue.Replace("Series", string.Empty).Trim();
                        var series = this.seriesRepo.All().FirstOrDefault(x => x.Name == seriesName);
                        if (series == null)
                        {
                            series = new Series
                            {
                                Name = seriesName,
                            };
                        }

                        memory.Series = series;
                        break;
                    case "Capacity":
                        var match = new Regex(@"\((?'quantity'\d)\s?[xX]\s?(?'capacity'\d+)(?'memorySize'[A-Za-z]+)\)").Match(rowValue);
                        if (match.Success)
                        {
                            memory.NumberOfModules = byte.Parse(match.Groups["quantity"].Value);
                            var size = match.Groups["memorySize"].Value;
                            var capacity = int.Parse(match.Groups["capacity"].Value);
                            if (size.ToLower() == "gb")
                            {
                                capacity *= 1024;
                            }

                            memory.CapacityPerModule = capacity;
                        }
                        else
                        {
                            memory.NumberOfModules = 1;
                            var digitMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                            if (!digitMatch.Success)
                            {
                                continue;
                            }

                            var capacity = int.Parse(digitMatch.Value);
                            if (rowValue.ToLower().Contains("gb"))
                            {
                                capacity *= 1024;
                            }

                            memory.CapacityPerModule = capacity;
                        }

                        break;
                    case "Type":
                        var typeMatch = new Regex(@"DDR\d\w?").Match(rowValue);
                        if (!typeMatch.Success)
                        {
                            continue;
                        }

                        var type = this.memoryTypeRepo.All().FirstOrDefault(x => x.Type == typeMatch.Value);
                        if (type == null)
                        {
                            type = new MemoryType
                            {
                                Type = typeMatch.Value,
                            };
                        }

                        memory.MemoryType = type;
                        break;
                    case "Speed":
                        var speedMatch = new Regex(@"\d{3,4}").Match(rowValue);
                        if (!speedMatch.Success)
                        {
                            continue;
                        }

                        var speed = this.memorySpeedRepo.All().FirstOrDefault(x => x.Speed == short.Parse(speedMatch.Value));
                        if (speed == null)
                        {
                            speed = new MemorySpeed
                            {
                                Speed = short.Parse(speedMatch.Value),
                            };
                        }

                        memory.MemorySpeed = speed;
                        break;
                    case "CAS Latency":
                        memory.ColumnAddressStrobeLatency = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Timing":
                        memory.Timings = rowValue;
                        break;
                    case "Voltage":
                        memory.Voltage = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Heat Spreader":
                        if (rowValue.ToLower().Contains("no") || rowValue.ToLower().Contains("none"))
                        {
                            memory.HeatSpreader = false;
                        }
                        else
                        {
                            memory.HeatSpreader = true;
                        }

                        break;
                    case "Features":
                        memory.Features = rowValue;
                        break;
                    case "Date First Available":
                        memory.FirstAvailable = DateTime.Parse(rowValue);
                        break;
                }
            }

            if (memory.Model == null)
            {
                this.logger.LogWarning("Invalid Model.");
                return;
            }

            await this.memoryRepo.AddAsync(memory);
            await this.memoryRepo.SaveChangesAsync();
            this.logger.LogInformation($"Successfully added {memory.Model}.");
        }
    }
}
