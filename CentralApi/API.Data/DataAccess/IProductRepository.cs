using System.Collections.Generic;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetTopProducts(int count);
        IEnumerable<Product> GetProducts(int pageIndex, int pageSize);
    }
}