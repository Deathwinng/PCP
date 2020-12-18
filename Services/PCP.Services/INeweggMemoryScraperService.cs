namespace PCP.Services
{
    using System.Threading.Tasks;

    public interface INeweggMemoryScraperService
    {
        Task ScrapeMemoryFromProductPageAsync(string productUrl);
    }
}
