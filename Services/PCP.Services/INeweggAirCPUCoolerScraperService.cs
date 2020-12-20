namespace PCP.Services
{
    using System.Threading.Tasks;

    public interface INeweggAirCPUCoolerScraperService
    {
        Task ScrapeAirCPUCoolerFromProductPageAsync(string productUrl);
    }
}
