namespace PCP.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PCP.Services;
    using PCP.Web.ViewModels.Scraper;

    public class NeweggScraperController : BaseController
    {
        private readonly ILogger<NeweggScraperController> logger;
        private readonly INeweggUrlScraperService neweggUrlScraper;
        private readonly INeweggCPUScraperService neweggCPUScraper;
        private readonly INeweggMotherboardScraperService neweggMotherboardScraper;
        private readonly INeweggGPUScraperService neweggGPUScraper;
        private readonly INeweggMemoryScraperService neweggMemoryScraper;
        private readonly INeweggHDDScraperService neweggHDDScraper;
        private readonly INeweggSSDScraperService neweggSSDScraper;
        private readonly INeweggCPUAirCoolerScraperService neweggCPUAirCoolerScraper;
        private readonly INeweggCaseScraperService neweggCaseScraper;

        public NeweggScraperController(
            ILogger<NeweggScraperController> logger,
            INeweggUrlScraperService neweggUrlScraper,
            INeweggCPUScraperService neweggCpuScraper,
            INeweggMotherboardScraperService neweggMotherboardScraper,
            INeweggGPUScraperService neweggGPUScraper,
            INeweggMemoryScraperService neweggMemoryScraper,
            INeweggHDDScraperService neweggHDDScraper,
            INeweggSSDScraperService neweggSSDScraper,
            INeweggCPUAirCoolerScraperService neweggCPUAirCoolerScraper,
            INeweggCaseScraperService neweggCaseScraper)
        {
            this.logger = logger;
            this.neweggUrlScraper = neweggUrlScraper;
            this.neweggCPUScraper = neweggCpuScraper;
            this.neweggMotherboardScraper = neweggMotherboardScraper;
            this.neweggGPUScraper = neweggGPUScraper;
            this.neweggMemoryScraper = neweggMemoryScraper;
            this.neweggHDDScraper = neweggHDDScraper;
            this.neweggSSDScraper = neweggSSDScraper;
            this.neweggCPUAirCoolerScraper = neweggCPUAirCoolerScraper;
            this.neweggCaseScraper = neweggCaseScraper;
        }

        public async Task<IActionResult> CPUs(string url, int pages)
        {
            var viewModel = await this.ScrapeManyAsync(this.neweggCPUScraper, url, pages);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> CPU(string url)
        {
            var viewModel = await this.ScrapeOne(this.neweggCPUScraper, url);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> Motherboards(string url, int pages)
        {
            var viewModel = await this.ScrapeManyAsync(this.neweggMotherboardScraper, url, pages);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> Motherboard(string url)
        {
            var viewModel = await this.ScrapeOne(this.neweggMotherboardScraper, url);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> GPUs(string url, int pages)
        {
            var viewModel = await this.ScrapeManyAsync(this.neweggGPUScraper, url, pages);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> GPU(string url)
        {
            var viewModel = await this.ScrapeOne(this.neweggGPUScraper, url);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> Memories(string url, int pages)
        {
            var viewModel = await this.ScrapeManyAsync(this.neweggMemoryScraper, url, pages);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> Memory(string url)
        {
            var viewModel = await this.ScrapeOne(this.neweggMemoryScraper, url);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> HDDs(string url, int pages)
        {
            var viewModel = await this.ScrapeManyAsync(this.neweggHDDScraper, url, pages);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> HDD(string url)
        {
            var viewModel = await this.ScrapeOne(this.neweggHDDScraper, url);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> SSDs(string url, int pages)
        {
            var viewModel = await this.ScrapeManyAsync(this.neweggSSDScraper, url, pages);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> SSD(string url)
        {
            var viewModel = await this.ScrapeOne(this.neweggSSDScraper, url);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> CPUAirCoolers(string url, int pages)
        {
            var viewModel = await this.ScrapeManyAsync(this.neweggCPUAirCoolerScraper, url, pages);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> CPUAirCooler(string url)
        {
            var viewModel = await this.ScrapeOne(this.neweggCPUAirCoolerScraper, url);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> Cases(string url, int pages)
        {
            var viewModel = await this.ScrapeManyAsync(this.neweggCaseScraper, url, pages);
            return this.View("Scraper", viewModel);
        }

        public async Task<IActionResult> Case(string url)
        {
            var viewModel = await this.ScrapeOne(this.neweggCaseScraper, url);
            return this.View("Scraper", viewModel);
        }

        private async Task<ScraperViewModel> ScrapeManyAsync(INeweggScraperService scraperService, string url, int pages)
        {
            var urls = this.neweggUrlScraper.GetUrlsForScrapingFromProducts(url, pages);
            var count = urls.Count;
            var counter = 0;
            var viewModel = new ScraperViewModel
            {
                NumberOfSuccessfullyAdded = 0,
                NumberOfErrors = 0,
            };
            this.logger.LogInformation(string.Empty + count);
            foreach (var u in urls)
            {
                var message = new ScraperViewModelMessage
                {
                    Url = u,
                };
                try
                {
                    message.Message = await scraperService.ScrapeFromProductPageAsync(u);
                    viewModel.NumberOfSuccessfullyAdded++;
                }
                catch (Exception exeption)
                {
                    this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
                    viewModel.NumberOfErrors++;
                    message.Message = exeption.Message;
                    message.InnerExeption = exeption.InnerException?.Message;
                }

                viewModel.Messages.Add(message);
                this.logger.LogInformation(string.Empty + (count - (++counter)));
            }

            return viewModel;
        }

        private async Task<ScraperViewModel> ScrapeOne(INeweggScraperService scraperService, string url)
        {
            var viewModel = new ScraperViewModel
            {
                NumberOfSuccessfullyAdded = 0,
                NumberOfErrors = 0,
            };
            var message = new ScraperViewModelMessage
            {
                Url = url,
            };
            try
            {
                message.Message = await scraperService.ScrapeFromProductPageAsync(url);
                viewModel.NumberOfSuccessfullyAdded++;
            }
            catch (Exception exeption)
            {
                this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
                viewModel.NumberOfErrors++;
                message.Message = exeption.Message;
                message.InnerExeption = exeption.InnerException.Message;
            }

            viewModel.Messages.Add(message);
            return viewModel;
        }
    }
}
