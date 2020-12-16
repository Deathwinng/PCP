namespace PCP.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using PCP.Services;

    public class TestController : BaseController
    {
        private readonly INeweggUrlScraperService neweggUrlScraper;
        private readonly INeweggCPUScraperService neweggCpuScraper;
        private readonly INeweggMotherboardScraperService neweggMotherboardScraper;

        public TestController(
            INeweggUrlScraperService neweggUrlScraper,
            INeweggCPUScraperService neweggCpuScraper,
            INeweggMotherboardScraperService neweggMotherboardScraper)
        {
            this.neweggUrlScraper = neweggUrlScraper;
            this.neweggCpuScraper = neweggCpuScraper;
            this.neweggMotherboardScraper = neweggMotherboardScraper;
        }

        public async Task<IActionResult> ScrapeCPUs(string url, int pages)
        {
            var urls = this.neweggUrlScraper.GetUrlsForScrapingFromProducts(url, pages);
            var count = urls.Count;
            var counter = 0;
            Console.WriteLine(count);
            foreach (var u in urls)
            {
                try
                {
                    await this.neweggCpuScraper.ScrapeCPUsFromProductPageAsync(u);
                }
                catch (Exception exeption)
                {
                    Console.WriteLine($"Exeption occured: {exeption.Message}.");
                }

                Console.WriteLine(count - (++counter));
            }

            return this.View(urls);
        }

        public async Task<IActionResult> ScrapeCPU(string url)
        {
            try
            {
                await this.neweggCpuScraper.ScrapeCPUsFromProductPageAsync(url);
            }
            catch (Exception exeption)
            {
                Console.WriteLine($"Exeption occured: {exeption.Message}.");
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
                    Console.WriteLine($"Exeption occured: {exeption.Message}.");
                }

                Console.WriteLine(count - (++counter));
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
                Console.WriteLine($"Exeption occured: {exeption.Message}.");
            }

            return this.View("ScrapeCPUs", new HashSet<string>());
        }
    }
}
