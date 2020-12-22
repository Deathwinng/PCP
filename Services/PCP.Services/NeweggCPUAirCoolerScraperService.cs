namespace PCP.Services
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using AngleSharp;
    using Microsoft.Extensions.Logging;
    using PCP.Data.Common.Repositories;
    using PCP.Data.Models;
    using PCP.Data.Models.CPUCooler;

    public class NeweggCPUAirCoolerScraperService : BaseNeweggProductScraperService, INeweggCPUAirCoolerScraperService
    {
        private readonly ILogger<NeweggCPUAirCoolerScraperService> logger;
        private readonly IDeletableEntityRepository<CPUAirCooler> coolerRepo;
        private readonly IDeletableEntityRepository<Brand> brandRepo;
        private readonly IDeletableEntityRepository<Series> seriesRepo;
        private readonly IDeletableEntityRepository<CoolerType> typeRepo;
        private readonly IDeletableEntityRepository<Socket> socketRepo;
        private readonly IDeletableEntityRepository<CPUAirCoolerSocket> coolerSocketRepo;
        private readonly IDeletableEntityRepository<CoolerBearingType> bearingTypeRepo;
        private readonly IDeletableEntityRepository<CoolerLEDType> ledTypeRepo;
        private readonly IDeletableEntityRepository<Color> colorRepo;
        private readonly IDeletableEntityRepository<Material> materialRepo;

        public NeweggCPUAirCoolerScraperService(
            ILogger<NeweggCPUAirCoolerScraperService> logger,
            IDeletableEntityRepository<CPUAirCooler> coolerRepo,
            IDeletableEntityRepository<Brand> brandRepo,
            IDeletableEntityRepository<Series> seriesRepo,
            IDeletableEntityRepository<CoolerType> typeRepo,
            IDeletableEntityRepository<Socket> socketRepo,
            IDeletableEntityRepository<CPUAirCoolerSocket> coolerSocketRepo,
            IDeletableEntityRepository<CoolerBearingType> bearingTypeRepo,
            IDeletableEntityRepository<CoolerLEDType> ledTypeRepo,
            IDeletableEntityRepository<Color> colorRepo,
            IDeletableEntityRepository<Material> materialRepo)
            : base()
        {
            this.logger = logger;
            this.coolerRepo = coolerRepo;
            this.brandRepo = brandRepo;
            this.seriesRepo = seriesRepo;
            this.typeRepo = typeRepo;
            this.socketRepo = socketRepo;
            this.coolerSocketRepo = coolerSocketRepo;
            this.bearingTypeRepo = bearingTypeRepo;
            this.ledTypeRepo = ledTypeRepo;
            this.colorRepo = colorRepo;
            this.materialRepo = materialRepo;
        }

        public async Task<string> ScrapeFromProductPageAsync(string productUrl)
        {
            if (productUrl.Contains("Combo"))
            {
                var message = "Invalid Product.";
                this.logger.LogWarning(message);
                return message;
            }

            var document = await this.Context.OpenAsync(productUrl);
            var coolerDataTableRows = this.GetAllTablesRows(document);
            var coolerDataTables = this.GetAllTables(document);
            var cooler = new CPUAirCooler
            {
                Price = this.GetPrice(document),
                ImageUrl = this.GetImageUrl(document),
                Category = this.GetCategoryFromUrl(productUrl),
            };

            this.logger.LogInformation(productUrl);

            foreach (var tableRow in coolerDataTableRows)
            {
                var rowName = tableRow.FirstChild.TextContent.Trim();
                var rowValue = tableRow.LastElementChild.InnerHtml.Replace("<br><br>", "{n}").Replace("<br>", "{n}").Trim();

                switch (rowName)
                {
                    case "Model":
                        if (this.coolerRepo.AllAsNoTracking().Any(x => x.Model == rowValue))
                        {
                            var message = "Already exists.";
                            this.logger.LogWarning(message);
                            return message;
                        }

                        cooler.Model = rowValue;
                        break;
                    case "Brand":
                        cooler.Brand = this.GetOrCreateBrand(this.brandRepo, rowValue);
                        break;
                    case "Series":
                        cooler.Series = this.GetOrCreateSeries(this.seriesRepo, rowValue);
                        break;
                    case "Type":
                        var type = this.typeRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (type == null)
                        {
                            type = new CoolerType
                            {
                                Name = rowValue,
                            };
                        }

                        cooler.CoolerType = type;
                        break;
                    case "Fan Size":
                        var sizeMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!sizeMatch.Success)
                        {
                            continue;
                        }

                        cooler.FanSize = short.Parse(sizeMatch.Value);
                        break;
                    case "CPU Socket Compatibility":
                        if (rowValue.ToLower().Contains("core"))
                        {
                            continue;
                        }

                        var socketsParts = new Regex(@"(?:Intel)|(?:AMD)|(?:LGA)|(?:Socket)|(?:and)")
                            .Replace(rowValue, "/")
                            .Replace("{n}", "/")
                            .Replace(":", string.Empty)
                            .Split(new char[] { '/', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var socketPart in socketsParts)
                        {
                            if (string.IsNullOrWhiteSpace(socketPart))
                            {
                                continue;
                            }

                            var socketName = socketPart.Trim();
                            var socket = this.socketRepo.All().FirstOrDefault(x => x.Name.Contains(socketName));
                            if (socket == null)
                            {
                                socket = new Socket
                                {
                                    Name = socketName,
                                };
                            }

                            var coolerSocket = this.coolerSocketRepo.AllAsNoTracking()
                                .FirstOrDefault(x => x.CPUAirCoolerId == cooler.Id && x.SocketId == socket.Id);
                            if (coolerSocket == null)
                            {
                                coolerSocket = new CPUAirCoolerSocket
                                {
                                    CPUAirCoolerId = cooler.Id,
                                    Socket = socket,
                                };
                            }

                            cooler.Sockets.Add(coolerSocket);
                        }

                        break;
                    case "Bearing Type":
                        var bearing = this.bearingTypeRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (bearing == null)
                        {
                            bearing = new CoolerBearingType
                            {
                                Name = rowValue,
                            };
                        }

                        cooler.CoolerBearingType = bearing;
                        break;
                    case "RPM":
                        var rpmMatches = this.MatchOneOrMoreDigits.Matches(rowValue.Replace(",", string.Empty));
                        var maxRpm = rpmMatches.Max(x => short.Parse(x.Value));
                        cooler.RPM = maxRpm;
                        break;
                    case "Air Flow":
                        cooler.MaxAirFlow = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Noise Level":
                        cooler.MaxNoiseLevel = this.MatchAndParseFloat(rowValue);
                        break;
                    case "Power Connector":
                        var powerPinsMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!powerPinsMatch.Success)
                        {
                            continue;
                        }

                        cooler.PowerConnectorPins = byte.Parse(powerPinsMatch.Value);
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

                        cooler.Color = color;
                        break;
                    case "LED":
                        var led = this.ledTypeRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (led == null)
                        {
                            led = new CoolerLEDType
                            {
                                Name = rowValue,
                            };
                        }

                        cooler.CoolerLED = led;
                        break;
                    case "Heatsink Material":
                        var heatsinkMaterial = this.materialRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (heatsinkMaterial == null)
                        {
                            heatsinkMaterial = new Material
                            {
                                Name = rowValue,
                            };
                        }

                        cooler.HeatsinkMaterial = heatsinkMaterial;
                        break;
                    case "Max CPU Cooler Height":
                        var maxHeightMatch = this.MatchOneOrMoreDigits.Match(rowValue);
                        if (!maxHeightMatch.Success)
                        {
                            continue;
                        }

                        cooler.MaxHeight = byte.Parse(maxHeightMatch.Value);
                        break;
                    case "Fan Dimensions":
                        cooler.FanDimensions = rowValue;
                        break;
                    case "Heatsink Dimensions":
                        cooler.HeatsinkDimension = rowValue;
                        break;
                    case "Features":
                        cooler.Features = rowValue;
                        break;
                    case "Date First Available":
                        cooler.FirstAvailable = DateTime.Parse(rowValue);
                        break;
                }
            }

            if (cooler.Model == null)
            {
                var message = "Invalid Model.";
                this.logger.LogWarning(message);
                return message;
            }

            await this.coolerRepo.AddAsync(cooler);
            await this.coolerRepo.SaveChangesAsync();
            var successMessage = $"Successfully added {cooler.Model}.";
            this.logger.LogInformation(successMessage);
            return successMessage;
        }

        // private T GetMaxValueOfMatches<T>(string stringToMatch)
        // {
        //    var rpmMatches = this.MatchOneOrMoreDigits.Matches(stringToMatch.Replace(",", string.Empty));
        //    T maxRpm;
        //    var converter = TypeDescriptor.GetConverter(typeof(T));
        //    if (converter != null)
        //    {
        //        maxRpm = rpmMatches.Max(x => (T)converter.ConvertFromString(x.Value));
        //        return maxRpm;
        //    }

        // return null;
        // }
    }
}
