namespace PCP.Services
{
    using System.Threading.Tasks;

    public interface INeweggSSDScraperService
    {
        Task ScrapeSSDFromProductPageAsync(string productUrl);
    }
}
