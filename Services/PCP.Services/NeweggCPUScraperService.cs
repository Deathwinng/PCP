namespace PCP.Services
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using AngleSharp;
    using Microsoft.Extensions.Logging;
    using PCP.Data.Common.Repositories;
    using PCP.Data.Models;
    using PCP.Data.Models.CPU;
    using PCP.Data.Models.Enums;

    public class NeweggCPUScraperService : NeweggProductScrapperBaseService, INeweggCPUScraperService
    {
        private readonly ILogger<NeweggCPUScraperService> logger;
        private readonly IDeletableEntityRepository<CPU> cpuRepo;
        private readonly IDeletableEntityRepository<Brand> brandRepo;
        private readonly IDeletableEntityRepository<Socket> socketRepo;
        private readonly IDeletableEntityRepository<Lithography> litographyrRepo;
        private readonly IDeletableEntityRepository<MemoryType> memoryTypeRepo;
        private readonly IDeletableEntityRepository<MemorySpeed> memorySpeedRepo;
        private readonly IDeletableEntityRepository<IntegratedGraphic> integratedGraphicRepo;
        private readonly IDeletableEntityRepository<CoreName> corenameRepo;
        private readonly IDeletableEntityRepository<Series> seriesRepo;

        public NeweggCPUScraperService(
            ILogger<NeweggCPUScraperService> logger,
            IDeletableEntityRepository<CPU> cpuRepo,
            IDeletableEntityRepository<Brand> brandRepo,
            IDeletableEntityRepository<Socket> socketRepo,
            IDeletableEntityRepository<Lithography> litographyrRepo,
            IDeletableEntityRepository<MemoryType> memoryTypeRepo,
            IDeletableEntityRepository<MemorySpeed> memorySpeedRepo,
            IDeletableEntityRepository<IntegratedGraphic> integratedGraphicRepo,
            IDeletableEntityRepository<CoreName> corenameRepo,
            IDeletableEntityRepository<Series> seriesRepo)
            : base()
        {
            this.logger = logger;
            this.cpuRepo = cpuRepo;
            this.brandRepo = brandRepo;
            this.socketRepo = socketRepo;
            this.litographyrRepo = litographyrRepo;
            this.memoryTypeRepo = memoryTypeRepo;
            this.memorySpeedRepo = memorySpeedRepo;
            this.integratedGraphicRepo = integratedGraphicRepo;
            this.corenameRepo = corenameRepo;
            this.seriesRepo = seriesRepo;
        }

        public async Task ScrapeCPUsFromProductPageAsync(string productUrl)
        {
            if (productUrl.Contains("Combo"))
            {
                this.logger.LogWarning("Invalid Product.");
                return;
            }

            var document = await this.Context.OpenAsync(productUrl);
            var cpuData = this.GetAllTablesRows(document);
            var integratedGrapicsData = new Dictionary<string, string>();
            var cpu = new CPU
            {
                Price = this.GetPrice(document),
                ImageUrl = this.GetImageUrl(document),
            };

            this.logger.LogInformation(productUrl);
            foreach (var tr in cpuData)
            {
                // this.logger.LogInformation(tr.InnerHtml);
                var rowName = tr.FirstChild.TextContent.Trim().Replace("<!-- --> ", string.Empty);
                var rowValue = tr.LastChild.TextContent.Trim();

                switch (rowName)
                {
                    case "Name":
                        if (this.cpuRepo.AllAsNoTracking().Any(x => x.Name == rowValue))
                        {
                            this.logger.LogWarning("Already exists.");
                            return;
                        }

                        cpu.Name = rowValue;
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

                        cpu.Brand = brand;
                        break;
                    case "Model":
                        cpu.Model = rowValue;
                        break;
                    case "Processors Type":
                        Category type;
                        Enum.TryParse<Category>(rowValue, out type);
                        cpu.Category = type;
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

                        cpu.Series = series;
                        break;
                    case "CPU Socket Type":
                        var socketName = rowValue.Replace("Socket ", string.Empty);
                        var socket = this.socketRepo.All().FirstOrDefault(x => x.Name == socketName);
                        if (socket == null)
                        {
                            socket = new Socket
                            {
                                Name = socketName,
                            };
                        }

                        cpu.Socket = socket;
                        break;
                    case "Core Name":
                        var coreName = this.corenameRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (coreName == null)
                        {
                            coreName = new CoreName
                            {
                                Name = rowValue,
                            };
                        }

                        cpu.CoreName = coreName;
                        break;
                    case "# of Cores":
                        var matchResult = this.MatchOneOrMoreDigits.Match(rowValue);
                        byte? numOfCores;
                        if (matchResult.Success)
                        {
                            numOfCores = byte.Parse(matchResult.Value);
                        }
                        else
                        {
                            numOfCores = rowValue.ToLower() switch
                            {
                                "single-core" => 1,
                                "dual-core" => 2,
                                "triple-core" => 3,
                                "quad-core" => 4,
                                "hexa-core" => 6,
                                "octa-core" => 8,
                                "10-core" => 10,
                                "12-core" => 12,
                                "16-core" => 16,
                                _ => null,
                            };
                        }

                        cpu.Cores = numOfCores;
                        break;
                    case "# of Threads":
                        var numOfTreads = this.MatchOneOrMoreDigits.Match(rowValue).Value;
                        cpu.Threads = short.Parse(numOfTreads);
                        break;
                    case "Operating Frequency":
                        var frequency = this.GetFrecuencyAsShort(rowValue);
                        cpu.Frequency = frequency;
                        break;
                    case "Max Turbo Frequency":
                        var turboFrequency = this.GetFrecuencyAsShort(rowValue);
                        cpu.TurboFrequency = turboFrequency;
                        break;
                    case "L1 Cache":
                        var l1Cache = this.GetCacheAsInt(rowValue);
                        cpu.L1Cache = l1Cache;
                        break;
                    case "L2 Cache":
                        var l2Cache = this.GetCacheAsInt(rowValue);
                        cpu.L2Cache = l2Cache;
                        break;
                    case "L3 Cache":
                        var l3Cache = this.GetCacheAsInt(rowValue);
                        cpu.L3Cache = l3Cache;
                        break;
                    case "Manufacturing Tech":
                        var litography = this.litographyrRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (litography == null)
                        {
                            litography = new Lithography
                            {
                                Name = rowValue,
                            };
                        }

                        cpu.Lithography = litography;
                        break;
                    case "64-Bit Support":
                        var sixtyFourBitSupport = rowValue.Contains("Yes");
                        cpu.SixtyFourBitSupport = sixtyFourBitSupport;
                        break;
                    case "Memory Types":
                        var typeMatch = new Regex(@"DDR\d\w?").Match(rowValue);
                        if (!typeMatch.Success)
                        {
                            continue;
                        }

                        var memoryTypeAsString = typeMatch.Value;
                        var memoryType = this.memoryTypeRepo.All().FirstOrDefault(x => x.Type == memoryTypeAsString);
                        if (memoryType == null)
                        {
                            memoryType = new MemoryType
                            {
                                Type = memoryTypeAsString,
                            };
                        }

                        var match = new Regex(@"\d{3,4}").Match(rowValue);
                        if (match.Success)
                        {
                            var memorySpeedAsShort = short.Parse(match.Value);

                            var memorySpeed = this.memorySpeedRepo.All().FirstOrDefault(x => x.Speed == memorySpeedAsShort);
                            if (memorySpeed == null)
                            {
                                memorySpeed = new MemorySpeed
                                {
                                    Speed = memorySpeedAsShort,
                                };
                            }

                            cpu.MemorySpeed = memorySpeed;
                        }

                        cpu.MemoryType = memoryType;
                        break;
                    case "Memory Channel":
                        cpu.MemoryChannel = byte.Parse(rowValue);
                        break;
                    case "Virtualization Technology Support":
                        cpu.VirtualizationSupport = rowValue.Contains("Yes");
                        break;
                    case "Integrated Graphics":
                        integratedGrapicsData["Name"] = rowValue;
                        break;
                    case "Graphics Base Frequency":
                        integratedGrapicsData["BaseFrequency"] = rowValue;
                        break;
                    case "Graphics Max Dynamic Frequency":
                        integratedGrapicsData["MaxFrequency"] = rowValue;
                        break;
                    case "PCI Express Revision":
                        cpu.PCIERevision = float.Parse(rowValue, CultureInfo.InvariantCulture);
                        break;
                    case "Max Number of PCI Express Lanes":
                        cpu.PCIELanes = byte.Parse(rowValue);
                        break;
                    case "Thermal Design Power":
                        var thermalDesignPower = this.MatchOneOrMoreDigits.Match(rowValue).Value;
                        cpu.ThermalDesignPower = short.Parse(thermalDesignPower);
                        break;
                    case "Cooling Device":
                        cpu.HasCoolingDevice = !rowValue.Contains("not included");
                        break;
                    case "Date First Available":
                        cpu.FirstAvailable = DateTime.Parse(rowValue);
                        break;
                    default:
                        break;
                }
            }

            if (integratedGrapicsData.ContainsKey("Name"))
            {
                var name = integratedGrapicsData["Name"];
                var integratedGrapic = this.integratedGraphicRepo.All()
                            .FirstOrDefault(x => x.Name == name);
                if (integratedGrapic == null)
                {
                    integratedGrapic = new IntegratedGraphic
                    {
                        Name = name,
                    };
                    if (integratedGrapicsData.ContainsKey("BaseFrequency"))
                    {
                        integratedGrapic.BaseFrequency = this.GetFrecuencyAsShort(integratedGrapicsData["BaseFrequency"]);
                    }

                    if (integratedGrapicsData.ContainsKey("MaxFrequency"))
                    {
                        integratedGrapic.MaxFrequency = this.GetFrecuencyAsShort(integratedGrapicsData["MaxFrequency"]);
                    }
                }

                cpu.IntegratedGraphic = integratedGrapic;
            }

            if (cpu.Name == null)
            {
                this.logger.LogWarning("Invalid Name.");
                return;
            }

            await this.cpuRepo.AddAsync(cpu);
            await this.cpuRepo.SaveChangesAsync();
        }

        private int GetCacheAsInt(string cacheAsString)
        {
            int result;
            if (cacheAsString.ToLower().Contains('x'))
            {
                var splitValues = cacheAsString.ToLower().Split('x');
                var value1 = int.Parse(this.MatchOneOrMoreDigits.Match(splitValues[0]).Value);
                var value2 = int.Parse(this.MatchOneOrMoreDigits.Match(splitValues[1]).Value);
                result = value1 * value2;
            }
            else if (cacheAsString.ToLower().Contains('+'))
            {
                var splitValues = cacheAsString.ToLower().Split('+');
                var value1 = int.Parse(this.MatchOneOrMoreDigits.Match(splitValues[0]).Value);
                var value2 = int.Parse(this.MatchOneOrMoreDigits.Match(splitValues[1]).Value);
                result = value1 + value2;
            }
            else
            {
                var value = this.MatchOneOrMoreDigitsFloat.Match(cacheAsString).Value;
                result = int.Parse(value, CultureInfo.InvariantCulture);
            }

            var isInMegabites = cacheAsString.ToLower().Contains("mb");
            if (isInMegabites)
            {
                result *= 1024;
            }

            return result;
        }
    }
}
