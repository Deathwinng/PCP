namespace PCP.Services
{
    using System.Threading.Tasks;

    public interface INeweggGPUScraperService
    {
        Task ScrapeGPUsFromProductPageAsync(string productUrl);
    }
}
