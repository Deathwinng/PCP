﻿namespace PCP.Web.Controllers
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

        public TestController(
            ILogger<TestController> logger,
            INeweggUrlScraperService neweggUrlScraper,
            INeweggCPUScraperService neweggCpuScraper,
            INeweggMotherboardScraperService neweggMotherboardScraper,
            INeweggGPUScraperService neweggGPUScraper)
        {
            this.logger = logger;
            this.neweggUrlScraper = neweggUrlScraper;
            this.neweggCPUScraper = neweggCpuScraper;
            this.neweggMotherboardScraper = neweggMotherboardScraper;
            this.neweggGPUScraper = neweggGPUScraper;
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
            Console.WriteLine(count);
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
    }
}