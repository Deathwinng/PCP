namespace PCP.Services
{
    using System.Collections.Generic;

    public interface INeweggUrlScraperService
    {
        ICollection<string> GetUrlsForScrapingFromProducts(string productsUrl, int pages);
    }
}
