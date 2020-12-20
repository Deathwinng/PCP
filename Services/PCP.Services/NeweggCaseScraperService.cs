namespace PCP.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using Microsoft.Extensions.Logging;
    using PCP.Data.Common.Repositories;
    using PCP.Data.Models;
    using PCP.Data.Models.Case;
    using PCP.Data.Models.Enums;

    public class NeweggCaseScraperService : BaseNeweggProductScraperService, INeweggCaseScraperService
    {
        private readonly ILogger<NeweggCaseScraperService> logger;
        private readonly IDeletableEntityRepository<Case> caseRepo;
        private readonly IDeletableEntityRepository<Brand> brandRepo;
        private readonly IDeletableEntityRepository<Series> seriesRepo;
        private readonly IDeletableEntityRepository<CaseType> caseTypeRepo;
        private readonly IDeletableEntityRepository<Color> colorRepo;
        private readonly IDeletableEntityRepository<Material> materialRepo;
        private readonly IDeletableEntityRepository<CaseMaterial> caseMaterialRepo;
        private readonly IDeletableEntityRepository<CaseFormFactor> caseFormFactorRepo;
        private readonly IDeletableEntityRepository<FormFactor> formFactorRepo;

        public NeweggCaseScraperService(
            ILogger<NeweggCaseScraperService> logger,
            IDeletableEntityRepository<Case> caseRepo,
            IDeletableEntityRepository<Brand> brandRepo,
            IDeletableEntityRepository<Series> seriesRepo,
            IDeletableEntityRepository<CaseType> caseTypeRepo,
            IDeletableEntityRepository<Color> colorRepo,
            IDeletableEntityRepository<Material> materialRepo,
            IDeletableEntityRepository<CaseMaterial> caseMaterialRepo,
            IDeletableEntityRepository<CaseFormFactor> caseFormFactorRepo,
            IDeletableEntityRepository<FormFactor> formFactorRepo)
            : base()
        {
            this.logger = logger;
            this.caseRepo = caseRepo;
            this.brandRepo = brandRepo;
            this.seriesRepo = seriesRepo;
            this.caseTypeRepo = caseTypeRepo;
            this.colorRepo = colorRepo;
            this.materialRepo = materialRepo;
            this.caseMaterialRepo = caseMaterialRepo;
            this.caseFormFactorRepo = caseFormFactorRepo;
            this.formFactorRepo = formFactorRepo;
        }

        public async Task ScrapeCaseFromProductPageAsync(string productUrl)
        {
            if (productUrl.Contains("Combo"))
            {
                this.logger.LogWarning("Invalid Product.");
                return;
            }

            var document = await this.Context.OpenAsync(productUrl);
            var caseDataTableRows = this.GetAllTablesRows(document);
            var caseDataTables = this.GetAllTables(document);
            var casePc = new Case
            {
                Price = this.GetPrice(document),
                ImageUrl = this.GetImageUrl(document),
                Category = this.GetCategoryFromUrl(productUrl),
                DownloadedRating = this.GetRatings(document),
            };
            casePc.DownloadedRating.ProductId = casePc.Id;

            this.logger.LogInformation(productUrl);

            foreach (var tableRow in caseDataTableRows)
            {
                var rowName = tableRow.FirstChild.TextContent.Trim();
                var rowValue = tableRow.LastElementChild.InnerHtml.Replace("<br><br>", "{n}").Replace("<br>", "{n}").Trim();

                switch (rowName)
                {
                    case "Model":
                        if (this.caseRepo.AllAsNoTracking().Any(x => x.Model == rowValue))
                        {
                            this.logger.LogWarning("Already exists.");
                            return;
                        }

                        casePc.Model = rowValue;
                        break;
                    case "Brand":
                        casePc.Brand = this.GetOrCreateBrand(this.brandRepo, rowValue);
                        break;
                    case "Series":
                        casePc.Series = this.GetOrCreateSeries(this.seriesRepo, rowValue);
                        break;
                    case "Type":
                        var type = this.caseTypeRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (type == null)
                        {
                            type = new CaseType
                            {
                                Name = rowValue,
                            };
                        }

                        casePc.CaseType = type;
                        break;
                    case "Color":
                        var color = this.colorRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (color == null)
                        {
                            color = new Color
                            {
                                Name = rowValue,
                            };
                        }

                        casePc.Color = color;
                        break;
                    case "Case Material":
                        var materialParts = rowValue.Split("/");
                        foreach (var materialPart in materialParts)
                        {
                            var materialName = materialPart.Trim();
                            if (this.caseMaterialRepo.AllAsNoTracking()
                                .Any(x => x.Material.Name == materialName && x.CaseId == casePc.Id))
                            {
                                continue;
                            }

                            var material = this.materialRepo.All().FirstOrDefault(x => x.Name == rowValue);
                            if (material == null)
                            {
                                material = new Material
                                {
                                    Name = rowValue,
                                };
                            }

                            var caseMaterial = new CaseMaterial
                            {
                                Material = material,
                                CaseId = casePc.Id,
                            };

                            casePc.CaseMaterials.Add(caseMaterial);
                        }

                        break;
                    case "With Power Supply":
                        bool? hasPowerSupply = null;
                        if (rowValue.ToLower().Contains("no"))
                        {
                            hasPowerSupply = false;
                        }
                        else if (rowValue.ToLower().Contains("yes"))
                        {
                            hasPowerSupply = true;
                        }

                        casePc.HasPowerSupply = hasPowerSupply;
                        break;
                    case "Power Supply Mounted":
                        casePc.CasePowerSupplyPosition = Enum.Parse<CasePowerSupplyPosition>(rowValue);
                        break;
                    case "Motherboard Compatibility":
                        var formFactorParts = rowValue.Split("/");
                        foreach (var formFactorPart in formFactorParts)
                        {
                            var formFactorName = formFactorPart.Trim();
                            if (this.caseFormFactorRepo.AllAsNoTracking()
                                .Any(x => x.FormFactor.Name == formFactorName && x.CaseId == casePc.Id))
                            {
                                continue;
                            }

                            var formFactor = this.formFactorRepo.All().FirstOrDefault(x => x.Name == formFactorName);
                            if (formFactor == null)
                            {
                                formFactor = new FormFactor
                                {
                                    Name = formFactorName,
                                };
                            }

                            var caseFormFactor = new CaseFormFactor
                            {
                                CaseId = casePc.Id,
                                FormFactor = formFactor,
                            };

                            casePc.CaseFormFactors.Add(caseFormFactor);
                        }

                        break;
                    case "Side Panel Window":
                        bool? hasPanelWindow = null;
                        if (rowValue.ToLower().Contains("no"))
                        {
                            hasPanelWindow = false;
                        }
                        else if (rowValue.ToLower().Contains("yes"))
                        {
                            hasPanelWindow = true;
                        }

                        casePc.SidePanelWindow = hasPanelWindow;
                        break;
                    case "Dust Filters":
                        casePc.DustFilters = rowValue;
                        break;
                    case "Internal 3.5\" Drive Bays":
                        var driveBay3point5Match = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!driveBay3point5Match.Success)
                        {
                            continue;
                        }

                        casePc.DriveBay3point5 = byte.Parse(driveBay3point5Match.Value);
                        break;
                    case "Internal 2.5\" Drive Bays":
                        var driveBay2point5Match = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!driveBay2point5Match.Success)
                        {
                            continue;
                        }

                        casePc.DriveBay2point5 = byte.Parse(driveBay2point5Match.Value);
                        break;
                    case "Expansion Slots":
                        var expansionSlotsMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!expansionSlotsMatch.Success)
                        {
                            continue;
                        }

                        casePc.ExpansionSlots = byte.Parse(expansionSlotsMatch.Value);
                        break;
                    case "Front Ports":
                        casePc.FrontPorts = rowValue;
                        break;
                    case "Fan Options":
                        casePc.FanOptions = rowValue;
                        break;
                    case "Radiator Options":
                        casePc.RadioatorOptions = rowValue;
                        break;
                    case "Max GPU Length":
                        var gpuLenghtMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!gpuLenghtMatch.Success)
                        {
                            continue;
                        }

                        casePc.MaxGPULength = short.Parse(gpuLenghtMatch.Value);
                        break;
                    case "Max CPU Cooler Height":
                        var cpuCoolerHeightMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!cpuCoolerHeightMatch.Success)
                        {
                            continue;
                        }

                        casePc.MaxCPUCoolerHeight = byte.Parse(cpuCoolerHeightMatch.Value);
                        break;
                    case "Max PSU Length":
                        var psuLenghtMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!psuLenghtMatch.Success)
                        {
                            continue;
                        }

                        casePc.MaxPSULenght = byte.Parse(psuLenghtMatch.Value);
                        break;
                    case "Dimensions (H x W x D)":
                        var dimensions = rowValue.Split("{n}")[0];
                        var dimensionsMatches = this.MatchOneOrMoreDigitsFloat.Matches(dimensions);
                        if (dimensionsMatches.Count >= 3)
                        {
                            casePc.Height = this.MatchAndParseFloat(dimensionsMatches[0].Value) * 2.54F;
                            casePc.Width = this.MatchAndParseFloat(dimensionsMatches[1].Value) * 2.54F;
                            casePc.Depth = this.MatchAndParseFloat(dimensionsMatches[2].Value) * 2.54F;
                        }

                        break;
                    case "Weight":
                        casePc.Weight = this.MatchAndParseFloat(rowValue) * 0.45F;
                        break;
                    case "Features":
                        casePc.Features = rowValue;
                        break;
                    case "Date First Available":
                        casePc.FirstAvailable = DateTime.Parse(rowValue);
                        break;
                }
            }

            if (casePc.Model == null)
            {
                this.logger.LogWarning("Invalid Model.");
                return;
            }

            await this.caseRepo.AddAsync(casePc);
            await this.caseRepo.SaveChangesAsync();
            this.logger.LogInformation($"Successfully added {casePc.Model}.");
        }
    }
}
