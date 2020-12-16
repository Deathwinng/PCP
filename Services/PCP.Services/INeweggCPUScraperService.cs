namespace PCP.Services
{
    using System.Threading.Tasks;

    public interface INeweggCPUScraperService
    {
        Task ScrapeCPUsFromProductPageAsync(string productUrl);
    }
}
