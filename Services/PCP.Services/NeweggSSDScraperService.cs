namespace PCP.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using Microsoft.Extensions.Logging;
    using PCP.Data.Common.Repositories;
    using PCP.Data.Models;
    using PCP.Data.Models.DiskDrive;

    public class NeweggSSDScraperService : BaseNeweggProductScraperService, INeweggSSDScraperService
    {
        private readonly ILogger<NeweggSSDScraperService> logger;
        private readonly IDeletableEntityRepository<SSD> ssdRepo;
        private readonly IDeletableEntityRepository<Brand> brandRepo;
        private readonly IDeletableEntityRepository<Series> seriesRepo;
        private readonly IDeletableEntityRepository<Interface> interfaceRepo;
        private readonly IDeletableEntityRepository<DiskForUsage> usageRepo;
        private readonly IDeletableEntityRepository<FormFactor> formFactorRepo;
        private readonly IDeletableEntityRepository<MemoryComponent> memoryComponentRepo;

        public NeweggSSDScraperService(
            ILogger<NeweggSSDScraperService> logger,
            IDeletableEntityRepository<SSD> ssdRepo,
            IDeletableEntityRepository<Brand> brandRepo,
            IDeletableEntityRepository<Series> seriesRepo,
            IDeletableEntityRepository<Interface> interfaceRepo,
            IDeletableEntityRepository<DiskForUsage> usageRepo,
            IDeletableEntityRepository<FormFactor> formFactorRepo,
            IDeletableEntityRepository<MemoryComponent> memoryComponentRepo)
            : base()
        {
            this.logger = logger;
            this.ssdRepo = ssdRepo;
            this.brandRepo = brandRepo;
            this.seriesRepo = seriesRepo;
            this.interfaceRepo = interfaceRepo;
            this.usageRepo = usageRepo;
            this.formFactorRepo = formFactorRepo;
            this.memoryComponentRepo = memoryComponentRepo;
        }

        public async Task ScrapeSSDFromProductPageAsync(string productUrl)
        {
            if (productUrl.Contains("Combo"))
            {
                this.logger.LogWarning("Invalid Product.");
                return;
            }

            var document = await this.Context.OpenAsync(productUrl);
            var ssdDataTableRows = this.GetAllTablesRows(document);
            var ssdDataTables = this.GetAllTables(document);
            var ssd = new SSD
            {
                Price = this.GetPrice(document),
                ImageUrl = this.GetImageUrl(document),
                Category = this.GetCategoryFromUrl(productUrl),
            };

            this.logger.LogInformation(productUrl);

            foreach (var tableRow in ssdDataTableRows)
            {
                var rowName = tableRow.FirstChild.TextContent.Trim();
                var rowValue = tableRow.LastChild.TextContent.Trim();

                switch (rowName)
                {
                    case "Model":
                        if (this.ssdRepo.AllAsNoTracking().Any(x => x.Model == rowValue))
                        {
                            this.logger.LogWarning("Already exists.");
                            return;
                        }

                        ssd.Model = rowValue;
                        break;
                    case "Brand":
                        ssd.Brand = this.GetOrCreateBrand(this.brandRepo, rowValue);
                        break;
                    case "Series":
                        ssd.Series = this.GetOrCreateSeries(this.seriesRepo, rowValue);
                        break;
                    case "Used For":
                        var usage = this.usageRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (usage == null)
                        {
                            usage = new DiskForUsage
                            {
                                Name = rowValue,
                            };
                        }

                        ssd.Usage = usage;
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

                        ssd.FormFactor = formFactor;
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

                        ssd.CapacityGb = capacity;
                        break;
                    case "Memory Components":
                        var memoryComponent = this.memoryComponentRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (memoryComponent == null)
                        {
                            memoryComponent = new MemoryComponent
                            {
                                Name = rowValue,
                            };
                        }

                        ssd.MemoryComponent = memoryComponent;
                        break;
                    case "Interface":
                        var ssdInterface = this.interfaceRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (ssdInterface == null)
                        {
                            ssdInterface = new Interface
                            {
                                Name = rowValue,
                            };
                        }

                        ssd.Interface = ssdInterface;
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
                        else if (rowValue.ToLower().Contains("gb"))
                        {
                            cache *= 1024 * 1024;
                        }

                        ssd.CacheKb = cache;
                        break;
                    case "Max Sequential Read":
                        var seqReadMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!seqReadMatch.Success)
                        {
                            continue;
                        }

                        ssd.MaxSequentialReadMBps = short.Parse(seqReadMatch.Value);
                        break;
                    case "Max Sequential Write":
                        var seqWriteMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!seqWriteMatch.Success)
                        {
                            continue;
                        }

                        ssd.MaxSequentialWriteMBps = short.Parse(seqWriteMatch.Value);
                        break;
                    case "4KB Random Read":
                        ssd.FourKBRandomRead = rowValue;
                        break;
                    case "4KB Random Write":
                        ssd.FourKBRandomWrite = rowValue;
                        break;
                    case "MTBF":
                        var mtbfMatch = this.MatchOneOrMoreDigits.Match(rowValue.Replace(",", string.Empty));
                        if (!mtbfMatch.Success)
                        {
                            continue;
                        }

                        ssd.MeanTimeBetweenFailures = int.Parse(mtbfMatch.Value);
                        break;
                    case "Features":
                        ssd.Features = rowValue;
                        break;
                    case "Height":
                        ssd.Height = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Width":
                        ssd.Width = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Depth":
                        ssd.Length = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Date First Available":
                        ssd.FirstAvailable = DateTime.Parse(rowValue);
                        break;
                }
            }

            if (ssd.Model == null)
            {
                this.logger.LogWarning("Invalid Model.");
                return;
            }

            await this.ssdRepo.AddAsync(ssd);
            await this.ssdRepo.SaveChangesAsync();
            this.logger.LogInformation($"Successfully added {ssd.Model}.");
        }
    }
}
