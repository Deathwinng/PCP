namespace PCP.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AngleSharp;
    using AngleSharp.Dom;

    public class NeweggUrlScraperService : INeweggUrlScraperService
    {
        private readonly IConfiguration configuration;
        private readonly IBrowsingContext context;

        public NeweggUrlScraperService()
        {
            this.configuration = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.configuration);
        }

        public ICollection<string> GetUrlsForScrapingFromProducts(string productsUrl, int pages)
        {
            var document = this.context.OpenAsync(productsUrl).GetAwaiter().GetResult();
            var urls = this.GetProductsUrls(document, pages);

            return urls;
        }

        private HashSet<string> GetProductsUrls(IDocument document, int pages)
        {
            var urls = new HashSet<string>();
            var page = 1;
            var lastPage = int.Parse(document.QuerySelector(".list-tool-pagination-text strong").TextContent.Split('/')[1]);
            var url = string.Empty;

            while (true)
            {
                var hrefs = document.QuerySelectorAll(".item-cells-wrap .item-cell .item-container > a")
                    .Select(x => x.GetAttribute("href")).ToList();

                foreach (var href in hrefs)
                {
                    urls.Add(href);
                }

                // var urlQuerriesArray = document.Location.Search.Split('&');
                // var urlQuerries = new Dictionary<string, string>();
                // foreach (var querry in urlQuerriesArray)
                // {
                //    var splitedQuerry = querry.Split('=');
                //    var key = splitedQuerry[0].Replace("?", string.Empty);
                //    urlQuerries[key] = splitedQuerry[1];
                // }
                url = document.Location.Href;

                if (url.Contains("Page"))
                {
                    url = url.Replace($"Page-{page}", $"Page-{++page}");
                }
                else
                {
                    var questionmarkIndex = url.IndexOf('?');
                    url = url.Insert(questionmarkIndex, $"/Page-{++page}");
                }

                if (page > lastPage || (pages != 0 && page > pages))
                {
                    break;
                }

                document = this.context.OpenAsync(url).GetAwaiter().GetResult();
            }

            return urls;
        }
    }
}
