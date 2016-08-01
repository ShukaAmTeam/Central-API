using System;
using System.Linq;
using System.Collections.Generic;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess.Repositories
{
    public class SaleOrderRepository : Repository<Products>, IOrderRepository
    {
        /// <exception cref="ArgumentNullException"><paramref name="context" /> is <see langword="null" />.</exception>
        public SaleOrderRepository(CentralDbEntities context)
            : base(context)
        {
           
        }

        public CentralDbEntities CentralDbContext => DbContext as CentralDbEntities;

        public IEnumerable<SaleOrders> GetSaleOrders(int pageIndex, int pageSize)
        {
            return CentralDbContext
                .SaleOrders
                .Skip((pageIndex - 1)*pageSize)
                .Take(pageSize);
        }

        public IEnumerable<SaleOrders> GetTopSaleOrders(int count)
        {
            return CentralDbContext
                .SaleOrders
                .Take(count);
        }
    }
}