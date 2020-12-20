namespace PCP.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using PCP.Services;

    public class TestController : BaseController
    {
        private readonly ILogger<TestController> logger;
        private readonly INeweggUrlScraperService neweggUrlScraper;
        private readonly INeweggCPUScraperService neweggCPUScraper;
        private readonly INeweggMotherboardScraperService neweggMotherboardScraper;
        private readonly INeweggGPUScraperService neweggGPUScraper;
        private readonly INeweggMemoryScraperService neweggMemoryScraper;
        private readonly INeweggHDDScraperService neweggHDDScraper;
        private readonly INeweggSSDScraperService neweggSSDScraper;
        private readonly INeweggAirCPUCoolerScraperService neweggAirCPUCoolerScraper;

        public TestController(
            ILogger<TestController> logger,
            INeweggUrlScraperService neweggUrlScraper,
            INeweggCPUScraperService neweggCpuScraper,
            INeweggMotherboardScraperService neweggMotherboardScraper,
            INeweggGPUScraperService neweggGPUScraper,
            INeweggMemoryScraperService neweggMemoryScraper,
            INeweggHDDScraperService neweggHDDScraper,
            INeweggSSDScraperService neweggSSDScraper,
            INeweggAirCPUCoolerScraperService neweggAirCPUCoolerScraper)
        {
            this.logger = logger;
            this.neweggUrlScraper = neweggUrlScraper;
            this.neweggCPUScraper = neweggCpuScraper;
            this.neweggMotherboardScraper = neweggMotherboardScraper;
            this.neweggGPUScraper = neweggGPUScraper;
            this.neweggMemoryScraper = neweggMemoryScraper;
            this.neweggHDDScraper = neweggHDDScraper;
            this.neweggSSDScraper = neweggSSDScraper;
            this.neweggAirCPUCoolerScraper = neweggAirCPUCoolerScraper;
        }

        public async Task<IActionResult> ScrapeCPUs(string url, int pages)
        {
            var urls = this.neweggUrlScraper.GetUrlsForScrapingFromProducts(url, pages);
            var count = urls.Count;
            var counter = 0;
            this.logger.LogInformation(string.Empty + count);
            foreach (var u in urls)
            {
                try
                {
                    await this.neweggCPUScraper.ScrapeCPUsFromProductPageAsync(u);
                }
                catch (Exception exeption)
                {
                    this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
                }

                this.logger.LogInformation(string.Empty + (count - (++counter)));
            }

            return this.View(urls);
        }

        public async Task<IActionResult> ScrapeCPU(string url)
        {
            try
            {
                await this.neweggCPUScraper.ScrapeCPUsFromProductPageAsync(url);
            }
            catch (Exception exeption)
            {
                this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
            }

            return this.View("ScrapeCPUs", new HashSet<string>());
        }

        public async Task<IActionResult> ScrapeMotherboards(string url, int pages)
        {
            var urls = this.neweggUrlScraper.GetUrlsForScrapingFromProducts(url, pages);
            var count = urls.Count;
            var counter = 0;
            this.logger.LogInformation(string.Empty + count);
            foreach (var u in urls)
            {
                try
                {
                    await this.neweggMotherboardScraper.ScrapeMotherboardFromProductPageAsync(u);
                }
                catch (Exception exeption)
                {
                    this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
                }

                this.logger.LogInformation(string.Empty + (count - (++counter)));
            }

            return this.View("ScrapeCPUs", urls);
        }

        public async Task<IActionResult> ScrapeMotherboard(string url)
        {
            try
            {
                await this.neweggMotherboardScraper.ScrapeMotherboardFromProductPageAsync(url);
            }
            catch (Exception exeption)
            {
                this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
            }

            return this.View("ScrapeCPUs", new HashSet<string>());
        }

        public async Task<IActionResult> ScrapeGPUs(string url, int pages)
        {
            var urls = this.neweggUrlScraper.GetUrlsForScrapingFromProducts(url, pages);
            var count = urls.Count;
            var counter = 0;
            this.logger.LogInformation(string.Empty + count);
            foreach (var u in urls)
            {
                try
                {
                    await this.neweggGPUScraper.ScrapeGPUsFromProductPageAsync(u);
                }
                catch (Exception exeption)
                {
                    this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
                }

                this.logger.LogInformation(string.Empty + (count - (++counter)));
            }

            return this.View("ScrapeCPUs", urls);
        }

        public async Task<IActionResult> ScrapeGPU(string url)
        {
            try
            {
                await this.neweggGPUScraper.ScrapeGPUsFromProductPageAsync(url);
            }
            catch (Exception exeption)
            {
                this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
            }

            return this.View("ScrapeCPUs", new HashSet<string>());
        }

        public async Task<IActionResult> ScrapeMemories(string url, int pages)
        {
            var urls = this.neweggUrlScraper.GetUrlsForScrapingFromProducts(url, pages);
            var count = urls.Count;
            var counter = 0;
            this.logger.LogInformation(string.Empty + count);
            foreach (var u in urls)
            {
                try
                {
                    await this.neweggMemoryScraper.ScrapeMemoryFromProductPageAsync(u);
                }
                catch (Exception exeption)
                {
                    this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
                }

                this.logger.LogInformation(string.Empty + (count - (++counter)));
            }

            return this.View("ScrapeCPUs", urls);
        }

        public async Task<IActionResult> ScrapeMemory(string url)
        {
            try
            {
                await this.neweggMemoryScraper.ScrapeMemoryFromProductPageAsync(url);
            }
            catch (Exception exeption)
            {
                this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
            }

            return this.View("ScrapeCPUs", new HashSet<string>());
        }

        public async Task<IActionResult> ScrapeHDDs(string url, int pages)
        {
            var urls = this.neweggUrlScraper.GetUrlsForScrapingFromProducts(url, pages);
            var count = urls.Count;
            var counter = 0;
            this.logger.LogInformation(string.Empty + count);
            foreach (var u in urls)
            {
                try
                {
                    await this.neweggHDDScraper.ScrapeHDDFromProductPageAsync(u);
                }
                catch (Exception exeption)
                {
                    this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
                }

                this.logger.LogInformation(string.Empty + (count - (++counter)));
            }

            return this.View("ScrapeCPUs", urls);
        }

        public async Task<IActionResult> ScrapeHDD(string url)
        {
            try
            {
                await this.neweggHDDScraper.ScrapeHDDFromProductPageAsync(url);
            }
            catch (Exception exeption)
            {
                this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
            }

            return this.View("ScrapeCPUs", new HashSet<string>());
        }

        public async Task<IActionResult> ScrapeSSDs(string url, int pages)
        {
            var urls = this.neweggUrlScraper.GetUrlsForScrapingFromProducts(url, pages);
            var count = urls.Count;
            var counter = 0;
            this.logger.LogInformation(string.Empty + count);
            foreach (var u in urls)
            {
                try
                {
                    await this.neweggSSDScraper.ScrapeSSDFromProductPageAsync(u);
                }
                catch (Exception exeption)
                {
                    this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
                }

                this.logger.LogInformation(string.Empty + (count - (++counter)));
            }

            return this.View("ScrapeCPUs", urls);
        }

        public async Task<IActionResult> ScrapeSSD(string url)
        {
            try
            {
                await this.neweggSSDScraper.ScrapeSSDFromProductPageAsync(url);
            }
            catch (Exception exeption)
            {
                this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
            }

            return this.View("ScrapeCPUs", new HashSet<string>());
        }

        public async Task<IActionResult> ScrapeCPUAirCoolers(string url, int pages)
        {
            var urls = this.neweggUrlScraper.GetUrlsForScrapingFromProducts(url, pages);
            var count = urls.Count;
            var counter = 0;
            this.logger.LogInformation(string.Empty + count);
            foreach (var u in urls)
            {
                try
                {
                    await this.neweggAirCPUCoolerScraper.ScrapeAirCPUCoolerFromProductPageAsync(u);
                }
                catch (Exception exeption)
                {
                    this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
                }

                this.logger.LogInformation(string.Empty + (count - (++counter)));
            }

            return this.View("ScrapeCPUs", urls);
        }

        public async Task<IActionResult> ScrapeCPUAirCooler(string url)
        {
            try
            {
                await this.neweggAirCPUCoolerScraper.ScrapeAirCPUCoolerFromProductPageAsync(url);
            }
            catch (Exception exeption)
            {
                this.logger.LogWarning($"Exeption occured: {exeption.Message}.");
            }

            return this.View("ScrapeCPUs", new HashSet<string>());
        }
    }
}
