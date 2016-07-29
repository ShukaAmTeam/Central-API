using System.Collections.Generic;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess
{
    public interface IProductRepository : IRepository<Products>
    {
        IEnumerable<Products> GetTopProducts(int count);
        IEnumerable<Products> GetProducts(int pageIndex, int pageSize);
    }
}