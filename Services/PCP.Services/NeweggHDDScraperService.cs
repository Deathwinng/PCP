﻿namespace PCP.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AngleSharp;
    using Microsoft.Extensions.Logging;
    using PCP.Data.Common.Repositories;
    using PCP.Data.Models;
    using PCP.Data.Models.HDD;
    using PCP.Data.Models.Memory;

    public class NeweggHDDScraperService : NeweggProductScrapperBaseService, INeweggHDDScraperService
    {
        private readonly ILogger<NeweggMemoryScraperService> logger;
        private readonly IDeletableEntityRepository<HDD> hddRepo;
        private readonly IDeletableEntityRepository<Brand> brandRepo;
        private readonly IDeletableEntityRepository<Series> seriesRepo;
        private readonly IDeletableEntityRepository<Interface> interfaceRepo;
        private readonly IDeletableEntityRepository<HDDUsage> usageRepo;
        private readonly IDeletableEntityRepository<FormFactor> formFactorRepo;

        public NeweggHDDScraperService(
            ILogger<NeweggMemoryScraperService> logger,
            IDeletableEntityRepository<HDD> hddRepo,
            IDeletableEntityRepository<Brand> brandRepo,
            IDeletableEntityRepository<Series> seriesRepo,
            IDeletableEntityRepository<Interface> interfaceRepo,
            IDeletableEntityRepository<HDDUsage> usageRepo,
            IDeletableEntityRepository<FormFactor> formFactorRepo)
            : base()
        {
            this.logger = logger;
            this.hddRepo = hddRepo;
            this.brandRepo = brandRepo;
            this.seriesRepo = seriesRepo;
            this.interfaceRepo = interfaceRepo;
            this.usageRepo = usageRepo;
            this.formFactorRepo = formFactorRepo;
        }

        public async Task ScrapeHDDFromProductPageAsync(string productUrl)
        {
            if (productUrl.Contains("Combo"))
            {
                this.logger.LogWarning("Invalid Product.");
                return;
            }

            var document = await this.Context.OpenAsync(productUrl);
            var hddDataTableRows = this.GetAllTablesRows(document);
            var hddDataTables = this.GetAllTables(document);
            var hdd = new HDD
            {
                Price = this.GetPrice(document),
                ImageUrl = this.GetImageUrl(document),
                Category = this.GetCategoryFromUrl(productUrl),
            };

            this.logger.LogInformation(productUrl);

            foreach (var tableRow in hddDataTableRows)
            {
                var rowName = tableRow.FirstChild.TextContent.Trim();
                var rowValue = tableRow.LastChild.TextContent.Trim();

                switch (rowName)
                {
                    case "Model":
                        if (this.hddRepo.AllAsNoTracking().Any(x => x.Model == rowValue))
                        {
                            this.logger.LogWarning("Already exists.");
                            return;
                        }

                        hdd.Model = rowValue;
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

                        hdd.Brand = brand;
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

                        hdd.Series = series;
                        break;
                    case "Interface":
                        var hddInterface = this.interfaceRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (hddInterface == null)
                        {
                            hddInterface = new Interface
                            {
                                Name = rowValue,
                            };
                        }

                        hdd.Interface = hddInterface;
                        break;
                    case "Capacity":
                        var capacityMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!capacityMatch.Success)
                        {
                            continue;
                        }

                        var capacity = short.Parse(capacityMatch.Value);
                        if (rowValue.ToLower().Contains("tb"))
                        {
                            capacity *= 1024;
                        }

                        hdd.CapacityGb = capacity;
                        break;
                    case "RPM":
                        var rpmMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!rpmMatch.Success)
                        {
                            continue;
                        }

                        hdd.RevolutionsPerMinute = short.Parse(rpmMatch.Value);
                        break;
                    case "Cache":
                        var cacheMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!cacheMatch.Success)
                        {
                            continue;
                        }

                        var cache = int.Parse(cacheMatch.Value);
                        if (rowValue.ToLower().Contains("mb"))
                        {
                            cache *= 1024;
                        }

                        hdd.CacheKb = cache;
                        break;
                    case "Features":
                        hdd.Features = rowValue;
                        break;
                    case "Usage":
                        var usage = this.usageRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (usage == null)
                        {
                            usage = new HDDUsage
                            {
                                Name = rowValue,
                            };
                        }

                        hdd.Usage = usage;
                        break;
                    case "Form Factor":
                        var formFactor = this.formFactorRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (formFactor == null)
                        {
                            formFactor = new FormFactor
                            {
                                Name = rowValue,
                            };
                        }

                        hdd.FormFactor = formFactor;
                        break;
                    case "Height (maximum)":
                        hdd.Height = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Width (maximum)":
                        hdd.Width = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Length (maximum)":
                        hdd.Length = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Date First Available":
                        hdd.FirstAvailable = DateTime.Parse(rowValue);
                        break;
                }
            }

            if (hdd.Model == null)
            {
                this.logger.LogWarning("Invalid Model.");
                return;
            }

            await this.hddRepo.AddAsync(hdd);
            await this.hddRepo.SaveChangesAsync();
            this.logger.LogInformation($"Successfully added {hdd.Model}.");
        }
    }
}