namespace PCP.Services
{
    using System.Threading.Tasks;

    public interface INeweggMotherboardScraperService
    {
        Task ScrapeMotherboardFromProductPageAsync(string productUrl);
    }
}
