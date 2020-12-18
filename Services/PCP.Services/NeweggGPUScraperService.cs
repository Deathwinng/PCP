namespace PCP.Services
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using Microsoft.Extensions.Logging;
    using PCP.Data.Common.Repositories;
    using PCP.Data.Models;
    using PCP.Data.Models.GPU;

    public class NeweggGPUScraperService : NeweggProductScrapperBaseService, INeweggGPUScraperService
    {
        private readonly ILogger<NeweggGPUScraperService> logger;
        private readonly IDeletableEntityRepository<GPU> gpuRepo;
        private readonly IDeletableEntityRepository<Brand> brandRepo;
        private readonly IDeletableEntityRepository<Series> seriesRepo;
        private readonly IDeletableEntityRepository<GPUInterface> interfeceRepo;
        private readonly IDeletableEntityRepository<MemoryType> memoryTypeRepo;
        private readonly IDeletableEntityRepository<GPUCore> coreRepo;
        private readonly IDeletableEntityRepository<GPUChipset> chipsetRepo;
        private readonly IDeletableEntityRepository<Port> portRepo;

        public NeweggGPUScraperService(
            ILogger<NeweggGPUScraperService> logger,
            IDeletableEntityRepository<GPU> gpuRepo,
            IDeletableEntityRepository<Brand> brandRepo,
            IDeletableEntityRepository<Series> seriesRepo,
            IDeletableEntityRepository<GPUInterface> interfeceRepo,
            IDeletableEntityRepository<MemoryType> memoryTypeRepo,
            IDeletableEntityRepository<GPUCore> coreRepo,
            IDeletableEntityRepository<GPUChipset> chipsetRepo,
            IDeletableEntityRepository<Port> portRepo)
            : base()
        {
            this.logger = logger;
            this.gpuRepo = gpuRepo;
            this.brandRepo = brandRepo;
            this.seriesRepo = seriesRepo;
            this.interfeceRepo = interfeceRepo;
            this.memoryTypeRepo = memoryTypeRepo;
            this.coreRepo = coreRepo;
            this.chipsetRepo = chipsetRepo;
            this.portRepo = portRepo;
        }

        public async Task ScrapeGPUsFromProductPageAsync(string productUrl)
        {
            if (productUrl.Contains("Combo"))
            {
                this.logger.LogWarning("Invalid Product.");
                return;
            }

            var document = await this.Context.OpenAsync(productUrl);
            var gpuDataTableRows = this.GetAllTablesRows(document);
            var gpuDataTables = this.GetAllTables(document);
            var gpu = new GPU
            {
                Price = this.GetPrice(document),
                ImageUrl = this.GetImageUrl(document),
                Category = this.GetCategoryFromUrl(productUrl),
            };

            foreach (var table in gpuDataTables)
            {
                var caption = table.FirstElementChild.TextContent;
                var tableRows = table.QuerySelectorAll("tr");

                switch (caption)
                {
                    case "Chipset":
                        var doesCoreAlreadyExist = false;
                        var doesChipsetAlreadyExist = false;
                        var gpuCore = new GPUCore();
                        var gpuChipset = new GPUChipset();
                        foreach (var tableRow in tableRows)
                        {
                            var rowName = tableRow.FirstChild.TextContent.Trim();
                            var rowValue = tableRow.LastChild.TextContent.Trim();

                            switch (rowName)
                            {
                                case "Chipset Manufacturer":
                                    var brand = this.brandRepo.All().FirstOrDefault(x => x.Name == rowValue);
                                    if (brand == null)
                                    {
                                        brand = new Brand
                                        {
                                            Name = rowValue,
                                        };
                                    }

                                    gpuCore.Brand = brand;
                                    break;
                                case "GPU Series":
                                    var seriesName = rowValue.Replace("Series", string.Empty).Trim();
                                    var series = this.seriesRepo.All().FirstOrDefault(x => x.Name == seriesName);
                                    if (series == null)
                                    {
                                        series = new Series
                                        {
                                            Name = seriesName,
                                        };
                                    }

                                    gpuCore.Series = series;
                                    break;
                                case "GPU":
                                    doesCoreAlreadyExist = this.coreRepo.All().Any(x => x.Name == rowValue);
                                    if (doesCoreAlreadyExist)
                                    {
                                        gpuCore = this.coreRepo.All().FirstOrDefault(x => x.Name == rowValue);
                                    }
                                    else
                                    {
                                        gpuCore.Name = rowValue;
                                    }

                                    break;
                                case "Core Clock":
                                    gpuChipset.CoreClock = this.GetFrecuencyAsShort(rowValue);
                                    break;
                                case "Boost Clock":
                                    gpuChipset.TurboClock = this.GetFrecuencyAsShort(rowValue);
                                    break;
                                case "CUDA Cores":
                                case "Stream Processors":
                                    if (!doesCoreAlreadyExist)
                                    {
                                        gpuCore.Cores = short.Parse(this.MatchOneOrMoreDigits.Match(rowValue).Value);
                                    }

                                    break;
                            }

                            if (this.chipsetRepo.AllAsNoTracking().Any(x =>
                                    x.CoreClock == gpuChipset.CoreClock &&
                                    x.TurboClock == gpuChipset.TurboClock &&
                                    x.GPUCore.Name == gpuCore.Name))
                            {
                                gpuChipset = this.chipsetRepo.All().FirstOrDefault(x =>
                                       x.CoreClock == gpuChipset.CoreClock &&
                                       x.TurboClock == gpuChipset.TurboClock &&
                                       x.GPUCore.Name == gpuCore.Name);
                                doesChipsetAlreadyExist = true;
                            }

                            if (doesCoreAlreadyExist && doesChipsetAlreadyExist)
                            {
                                break;
                            }
                        }

                        gpuChipset.GPUCore = gpuCore;
                        gpu.GPUChipset = gpuChipset;
                        break;
                    case "Ports":
                        foreach (var tableRow in tableRows)
                        {
                            var rowName = tableRow.FirstChild.TextContent.Trim();
                            var rowValue = tableRow.LastChild.TextContent.Trim();

                            if (rowName == "Multi-Monitor Support")
                            {
                                continue;
                            }

                            var port = this.portRepo.All().FirstOrDefault(x => x.Name == rowName);
                            if (port == null)
                            {
                                port = new Port
                                {
                                    Name = rowName,
                                };
                                await this.portRepo.AddAsync(port);
                                await this.portRepo.SaveChangesAsync();
                            }

                            var quantity = byte.Parse(this.MatchOneOrMoreDigits.Match(rowValue).Value);
                            var gpuPort = new GPUPort
                            {
                                GPU = gpu,
                                Port = port,
                                Quantity = quantity,
                            };

                            gpu.GPUPorts.Add(gpuPort);
                        }

                        break;
                }
            }

            foreach (var tableRow in gpuDataTableRows)
            {
                var rowName = tableRow.FirstChild.TextContent.Trim();
                var rowValue = tableRow.LastChild.TextContent.Trim();

                switch (rowName)
                {
                    case "Model":
                        if (this.gpuRepo.AllAsNoTracking().Any(x => x.Model == rowValue))
                        {
                            this.logger.LogWarning("Already exists.");
                            return;
                        }

                        gpu.Model = rowValue;
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

                        gpu.Brand = brand;
                        break;
                    case "Series":
                        var series = this.seriesRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (series == null)
                        {
                            series = new Series
                            {
                                Name = rowValue,
                            };
                        }

                        gpu.Series = series;
                        break;
                    case "Interface":
                        var gpuInterface = this.interfeceRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (gpuInterface == null)
                        {
                            gpuInterface = new GPUInterface
                            {
                                Name = rowValue,
                            };
                        }

                        gpu.GPUInterface = gpuInterface;
                        break;
                    case "Effective Memory Clock":
                        if (rowValue.ToLower().Contains("hz"))
                        {
                            continue;
                        }

                        var bandwidthMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!bandwidthMatch.Success)
                        {
                            continue;
                        }

                        gpu.MemoryBandwidth = byte.Parse(bandwidthMatch.Value);
                        break;
                    case "Memory Size":
                        var sizeMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!sizeMatch.Success)
                        {
                            continue;
                        }

                        gpu.MemorySize = int.Parse(sizeMatch.Value) * 1024;
                        break;
                    case "Memory Interface":
                        var memoryInterfaceMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!memoryInterfaceMatch.Success)
                        {
                            continue;
                        }

                        gpu.MemoryInterface = short.Parse(memoryInterfaceMatch.Value);
                        break;
                    case "Memory Type":
                        var memoryType = this.memoryTypeRepo.All().FirstOrDefault(x => x.Type == rowValue);
                        if (memoryType == null)
                        {
                            memoryType = new MemoryType
                            {
                                Type = rowValue,
                            };
                        }

                        gpu.MemoryType = memoryType;
                        break;
                    case "DirectX":
                        var directXVersionMatch = this.MatchOneOrMoreDigitsFloat.Match(rowValue);
                        if (!directXVersionMatch.Success)
                        {
                            continue;
                        }

                        float.TryParse(directXVersionMatch.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out float directXVersion);
                        gpu.DirectXVersion = directXVersion;
                        break;
                    case "OpenGL":
                        var openGLVersionMatch = this.MatchOneOrMoreDigitsFloat.Match(rowValue);
                        if (!openGLVersionMatch.Success)
                        {
                            continue;
                        }

                        float.TryParse(openGLVersionMatch.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out float openGLVersion);
                        gpu.OpenGLVersion = openGLVersion;
                        break;
                    case "Thermal Design Power":
                        var tdpMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!tdpMatch.Success)
                        {
                            continue;
                        }

                        short.TryParse(tdpMatch.Value, out short tdp);
                        gpu.ThermalDesignPower = tdp;
                        break;
                    case "Features":
                        gpu.Features = rowValue;
                        break;
                    case "Card Dimensions (L x H)":
                        var dimensionsSplit = rowValue.Split('x');
                        var lenghtInInch = this.MatchAndParseFloat(dimensionsSplit[0]);
                        var heightInInch = this.MatchAndParseFloat(dimensionsSplit[1]);
                        gpu.Length = lenghtInInch * 2.54F;
                        gpu.Height = heightInInch * 2.54F;
                        break;
                    case "Slot Width":
                        var slotWidthMatch = this.MatchOneOrMoreDigitsFloat.Match(rowValue);
                        if (slotWidthMatch.Success)
                        {
                            float.TryParse(slotWidthMatch.Value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out float slotWidth);
                            gpu.SlotWidth = slotWidth;
                        }
                        else
                        {
                            gpu.SlotWidth = rowValue.ToLower() switch
                            {
                                "single slot" => 1.0F,
                                "dual slot" => 2.0F,
                                "tripple slot" => 3.0F,
                                _ => null,
                            };
                        }

                        break;
                    case "Date First Available":
                        gpu.FirstAvailable = DateTime.Parse(rowValue);
                        break;
                    default:
                        break;
                }
            }

            if (gpu.Model == null)
            {
                this.logger.LogWarning("Invalid Model.");
                return;
            }

            await this.gpuRepo.AddAsync(gpu);
            await this.gpuRepo.SaveChangesAsync();
            this.logger.LogInformation($"Successfully added {gpu.Model}.");
        }
    }
}
