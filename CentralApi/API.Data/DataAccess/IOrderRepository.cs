using System.Collections.Generic;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess
{
    public interface IOrderRepository : IRepository<Products>
    {
        IEnumerable<SaleOrders> GetTopSaleOrders(int count);
        IEnumerable<SaleOrders> GetSaleOrders(int pageIndex, int pageSize);
    }
}