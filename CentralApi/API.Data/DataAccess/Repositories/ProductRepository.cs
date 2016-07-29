using System;
using System.Linq;
using System.Collections.Generic;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        /// <exception cref="ArgumentNullException"><paramref name="context" /> is <see langword="null" />.</exception>
        public ProductRepository(CentralDbEntities context)
            : base(context)
        {
        }

        public CentralDbEntities CentralDbContext => DbContext as CentralDbEntities;

        public IEnumerable<Product> GetProducts(int pageIndex, int pageSize)
        {
            return CentralDbContext
                .Products.Skip((pageIndex - 1)*pageSize)
                .Take(pageSize);
        }

        public IEnumerable<Product> GetTopProducts(int count)
        {
            return CentralDbContext.Products
                .Take(count);
        }
    }
}