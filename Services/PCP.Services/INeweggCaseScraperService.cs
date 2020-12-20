namespace PCP.Services
{
    using System.Threading.Tasks;

    public interface INeweggCaseScraperService
    {
        Task ScrapeCaseFromProductPageAsync(string productUrl);
    }
}
