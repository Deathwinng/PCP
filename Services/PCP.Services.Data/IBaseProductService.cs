
namespace PCP.Services.Data
{
    using System.Collections.Generic;

    public interface IBaseProductService
    {
        T GetById<T>(string id);

        IEnumerable<T> GetAll<T>(int page, int productsPerPage);

        IEnumerable<T> GetRandom<T>(int count);

        int GetProductsCount();
    }
}
