using System.Collections.Generic;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess
{
    public interface IOrderRepository : IRepository<Product>
    {
        IEnumerable<Order> GetTopOrders(int count);
        IEnumerable<Order> GetOrders(int pageIndex, int pageSize);
    }
}