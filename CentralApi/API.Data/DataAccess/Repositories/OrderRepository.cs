using System;
using System.Linq;
using System.Collections.Generic;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess.Repositories
{
    public class OrderRepository : Repository<Products>, IOrderRepository
    {
        /// <exception cref="ArgumentNullException"><paramref name="context" /> is <see langword="null" />.</exception>
        public OrderRepository(CentralDbEntities context)
            : base(context)
        {
        }

        public CentralDbEntities CentralDbContext => DbContext as CentralDbEntities;

        public IEnumerable<Orders> GetOrders(int pageIndex, int pageSize)
        {
            return CentralDbContext
                .Orders.Skip((pageIndex - 1)*pageSize)
                .Take(pageSize);
        }

        public IEnumerable<Orders> GetTopOrders(int count)
        {
            return CentralDbContext.Orders
                .Take(count);
        }
    }
}