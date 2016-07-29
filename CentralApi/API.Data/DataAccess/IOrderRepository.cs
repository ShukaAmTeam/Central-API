using System.Collections.Generic;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess
{
    public interface IOrderRepository : IRepository<Products>
    {
        IEnumerable<Orders> GetTopOrders(int count);
        IEnumerable<Orders> GetOrders(int pageIndex, int pageSize);
    }
}