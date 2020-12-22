namespace PCP.Services
{
    using System.Threading.Tasks;

    public interface INeweggScraperService
    {
        Task<string> ScrapeFromProductPageAsync(string productUrl);
    }
}
