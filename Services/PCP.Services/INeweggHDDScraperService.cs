namespace PCP.Services
{
    using System.Threading.Tasks;

    public interface INeweggHDDScraperService
    {
        Task ScrapeHDDFromProductPageAsync(string productUrl);
    }
}
