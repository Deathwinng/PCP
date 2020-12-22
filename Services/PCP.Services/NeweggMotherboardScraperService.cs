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
    using PCP.Data.Models.Motherboard;

    public class NeweggMotherboardScraperService : BaseNeweggProductScraperService, INeweggMotherboardScraperService
    {
        private readonly ILogger<NeweggMotherboardScraperService> logger;
        private readonly IDeletableEntityRepository<Motherboard> motherboardRepo;
        private readonly IDeletableEntityRepository<Brand> brandRepo;
        private readonly IDeletableEntityRepository<Series> seriesRepo;
        private readonly IDeletableEntityRepository<Socket> socketRepo;
        private readonly IDeletableEntityRepository<MothrboardChipset> chipsetreopo;
        private readonly IDeletableEntityRepository<MemoryType> memoryTypeRepo;
        private readonly IDeletableEntityRepository<MemorySpeed> memorySpeedRepo;
        private readonly IDeletableEntityRepository<MotherboardMemoryType> motherboardMemoryTypeRepo;
        private readonly IDeletableEntityRepository<AudioChipset> audioChipsetRepo;
        private readonly IDeletableEntityRepository<FormFactor> formFactorRepo;
        private readonly IDeletableEntityRepository<LanChipset> lanChipsetRepo;

        public NeweggMotherboardScraperService(
            ILogger<NeweggMotherboardScraperService> logger,
            IDeletableEntityRepository<Motherboard> motherboardRepo,
            IDeletableEntityRepository<Brand> brandRepo,
            IDeletableEntityRepository<Series> seriesRepo,
            IDeletableEntityRepository<Socket> socketRepo,
            IDeletableEntityRepository<MothrboardChipset> chipsetReopo,
            IDeletableEntityRepository<MemoryType> memoryTypeRepo,
            IDeletableEntityRepository<MemorySpeed> memorySpeedRepo,
            IDeletableEntityRepository<MotherboardMemoryType> motherboardMemoryTypeRepo,
            IDeletableEntityRepository<AudioChipset> audioChipsetRepo,
            IDeletableEntityRepository<FormFactor> formFactorRepo,
            IDeletableEntityRepository<LanChipset> lanChipsetRepo)
            : base()
        {
            this.logger = logger;
            this.motherboardRepo = motherboardRepo;
            this.brandRepo = brandRepo;
            this.seriesRepo = seriesRepo;
            this.socketRepo = socketRepo;
            this.chipsetreopo = chipsetReopo;
            this.memoryTypeRepo = memoryTypeRepo;
            this.memorySpeedRepo = memorySpeedRepo;
            this.motherboardMemoryTypeRepo = motherboardMemoryTypeRepo;
            this.audioChipsetRepo = audioChipsetRepo;
            this.formFactorRepo = formFactorRepo;
            this.lanChipsetRepo = lanChipsetRepo;
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
            var motherboardDataTableRows = this.GetAllTablesRows(document);
            var motherboardDataTables = this.GetAllTables(document);
            var motherboard = new Motherboard
            {
                Price = this.GetPrice(document),
                ImageUrl = this.GetImageUrl(document),
                Category = this.GetCategoryFromUrl(productUrl),
            };

            foreach (var table in motherboardDataTables)
            {
                var caption = table.FirstElementChild.TextContent;
                var tableRows = table.QuerySelectorAll("tr");

                switch (caption)
                {
                    case "Onboard Audio":
                        var audioChipsetName = tableRows[0].LastChild.TextContent.Trim();
                        var firstLine = tableRows[1].LastElementChild
                                .InnerHtml.Replace("<br><br>", "{n}").Replace("<br>", "{n}").Trim().Split("{n}");
                        var matches = this.MatchOneOrMoreDigitsFloat.Matches(firstLine[0]);
                        float channels = 0;
                        foreach (Match match in matches)
                        {
                            channels = Math.Max(channels, float.Parse(match.Value, CultureInfo.InvariantCulture));
                        }

                        var audioChipset = this.audioChipsetRepo.All().FirstOrDefault(x => x.Name == audioChipsetName);
                        if (audioChipset == null)
                        {
                            audioChipset = new AudioChipset
                            {
                                Name = audioChipsetName,
                                Channels = channels,
                            };
                        }

                        motherboard.AudioChipset = audioChipset;
                        break;
                    case "Onboard LAN":
                        var lanChipsetName = tableRows[0].LastChild.TextContent.Trim();
                        var lanChipset = this.lanChipsetRepo.All().FirstOrDefault(x => x.Name == lanChipsetName);
                        if (lanChipset == null)
                        {
                            lanChipset = new LanChipset
                            {
                                Name = lanChipsetName,
                            };
                        }

                        motherboard.LanChipset = lanChipset;
                        break;
                    case "Rear Panel Ports":
                        var ports = string.Empty;
                        foreach (var tableRow in tableRows)
                        {
                            if (tableRow.FirstChild.TextContent != "Back I/O Ports")
                            {
                                ports += tableRow.LastChild.TextContent.Trim() + Environment.NewLine;
                            }
                        }

                        if (!string.IsNullOrEmpty(ports))
                        {
                            motherboard.RearPanelPorts = ports;
                        }

                        break;
                }
            }

            this.logger.LogInformation(productUrl);

            foreach (var tableRow in motherboardDataTableRows)
            {
                var rowName = tableRow.FirstChild.TextContent.Trim();
                var rowValue = tableRow.LastElementChild.InnerHtml.Replace("<br><br>", "{n}").Replace("<br>", "{n}").Trim();

                switch (rowName)
                {
                    case "Model":
                        if (this.motherboardRepo.AllAsNoTracking().Any(x => x.Model == rowValue))
                        {
                            var message = "Already exists.";
                            this.logger.LogWarning(message);
                            return message;
                        }

                        motherboard.Model = rowValue;
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

                        motherboard.Brand = brand;
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

                        motherboard.Series = series;
                        break;
                    case "CPU Socket Type":
                        var socket = this.socketRepo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (socket == null)
                        {
                            socket = new Socket
                            {
                                Name = rowValue,
                            };
                        }

                        motherboard.Socket = socket;
                        break;
                    case "Chipset":
                        var chipset = this.chipsetreopo.All().FirstOrDefault(x => x.Name == rowValue);
                        if (chipset == null)
                        {
                            chipset = new MothrboardChipset
                            {
                                Name = rowValue,
                            };
                        }

                        motherboard.Chipset = chipset;
                        break;
                    case "Number of Memory Slots":
                        motherboard.MemorySlots = int.Parse(this.MatchOneOrMoreDigits.Match(rowValue).Value);
                        break;
                    case "Memory Standard":
                        var lines = rowValue.Split("{n}");
                        foreach (var line in lines)
                        {
                            var typeMatch = new Regex(@"DDR\d\w?").Match(line);
                            if (!typeMatch.Success)
                            {
                                continue;
                            }

                            var memoryTypeAsString = typeMatch.Value;
                            var matches = new Regex(@"\d{3,4}").Matches(line);
                            foreach (Match match in matches)
                            {
                                var memorySpeedAsShort = short.Parse(match.Value);

                                var motherboardMemoryType = this.motherboardMemoryTypeRepo.All()
                                    .FirstOrDefault(x => x.MotherboardId == motherboard.Id && x.MemoryType.Type == memoryTypeAsString &&
                                        x.MemorySpeed.Speed == memorySpeedAsShort);
                                if (motherboardMemoryType != null)
                                {
                                    continue;
                                }

                                var memoryType = this.memoryTypeRepo.All().FirstOrDefault(x => x.Type == memoryTypeAsString);
                                if (memoryType == null)
                                {
                                    memoryType = new MemoryType
                                    {
                                        Type = memoryTypeAsString,
                                    };
                                    await this.memoryTypeRepo.AddAsync(memoryType);
                                    await this.memoryTypeRepo.SaveChangesAsync();
                                }

                                var memorySpeed = this.memorySpeedRepo.All().FirstOrDefault(x => x.Speed == memorySpeedAsShort);
                                if (memorySpeed == null)
                                {
                                    memorySpeed = new MemorySpeed
                                    {
                                        Speed = memorySpeedAsShort,
                                    };
                                    await this.memorySpeedRepo.AddAsync(memorySpeed);
                                    await this.memorySpeedRepo.SaveChangesAsync();
                                }

                                motherboardMemoryType = new MotherboardMemoryType
                                {
                                    Motherboard = motherboard,
                                    MemoryType = memoryType,
                                    MemorySpeed = memorySpeed,
                                };
                                motherboard.MotherboardMemoryType.Add(motherboardMemoryType);
                            }
                        }

                        break;
                    case "Maximum Memory Supported":
                        var maximumMemory = int.Parse(this.MatchOneOrMoreDigits.Match(rowValue).Value);
                        if (rowValue.ToLower().Contains("gb"))
                        {
                            maximumMemory *= 1024;
                        }

                        motherboard.MaxMemorySupport = maximumMemory;
                        break;
                    case "Channel Supported":
                        byte? channel = rowValue.ToLower() switch
                        {
                            "dual channel" => 2,
                            "triple channel" => 3,
                            "quad channel" => 4,
                            _ => null,
                        };
                        motherboard.MemoryChannel = channel;
                        break;
                    case "PCI Express 3.0 x16":
                        motherboard.PCIe3x16 = this.GetNumberOfSlots(@"(?'slots'\d) x PCI", rowValue);
                        break;
                    case "PCI Express 4.0 x16":
                        motherboard.PCIe4x16 = this.GetNumberOfSlots(@"(?'slots'\d) x PCI", rowValue);
                        break;
                    case "PCI Express x1":
                        motherboard.PCIex1 = this.GetNumberOfSlots(@"(?'slots'\d) x PCI", rowValue);
                        break;
                    case "SATA 6Gb/s":
                        motherboard.Sata6Gbs = this.GetNumberOfSlots(@"(?'slots'\d) x SATA", rowValue);
                        break;
                    case "SATA 3Gb/s":
                        motherboard.Sata3Gbs = this.GetNumberOfSlots(@"(?'slots'\d) x SATA", rowValue);
                        break;
                    case "M.2":
                        motherboard.Mdot2 = this.GetNumberOfSlots(@"(?'slots'\d) x M\.", rowValue);
                        break;
                    case "Back I/O Ports":
                        motherboard.RearPanelPorts = rowValue.Replace("\n", "NewLine");
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

                        motherboard.FormFactor = formFactor;
                        break;
                    case "Dimensions (W x L)":
                        var dimensionsSplit = rowValue.Split('x');
                        var widthInInch = this.MatchAndParseFloat(dimensionsSplit[0]);
                        var lengthInInch = this.MatchAndParseFloat(dimensionsSplit[1]);
                        motherboard.Width = widthInInch * 2.54F;
                        motherboard.Length = lengthInInch * 2.54F;
                        break;
                    case "Features":
                        motherboard.Features = rowValue;
                        break;
                    case "Date First Available":
                        motherboard.FirstAvailable = DateTime.Parse(rowValue);
                        break;
                }
            }

            if (motherboard.Model == null)
            {
                var message = "Invalid Model.";
                this.logger.LogWarning(message);
                return message;
            }

            await this.motherboardRepo.AddAsync(motherboard);
            await this.motherboardRepo.SaveChangesAsync();
            var successMessage = $"Successfully added {motherboard.Model}.";
            this.logger.LogInformation(successMessage);
            return successMessage;
        }

        private byte GetNumberOfSlots(string regexExpression, string from)
        {
            var pcieMatches = new Regex(regexExpression).Matches(from);
            byte slots = 0;

            foreach (Match match in pcieMatches)
            {
                foreach (Group group in match.Groups)
                {
                    if (group.Name == "slots")
                    {
                        slots += byte.Parse(group.Value);
                    }
                }
            }

            return slots;
        }
    }
}
