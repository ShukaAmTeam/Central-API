using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using API.Data.DataAccess;
using API.Data.DataAccess.Repositories;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.UnitOfWork
{
    public class CentralDbUoW : ICentralDbUoW
    {
        private readonly CentralDbEntities _context;

        /// <exception cref="ArgumentNullException"><paramref name="context" /> is <see langword="null" />.</exception>
        public CentralDbUoW(CentralDbEntities context)
        {
            _context = context;
            Order = new OrderRepository(_context);
            Product = new ProductRepository(_context);
        }

        public IOrderRepository Order { get; private set; }

        public IProductRepository Product { get; private set; }

        /// <exception cref="DbEntityValidationException">
        ///             The save was aborted because validation of entity property values failed.
        ///             </exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///             A database command did not affect the expected number of rows. This usually indicates an optimistic 
        ///             concurrency violation; that is, a row has been changed in the database since it was queried.
        ///             </exception>
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        /// <exception cref="NotSupportedException">
        ///             An attempt was made to use unsupported behavior such as executing multiple asynchronous commands concurrently
        ///             on the same context instance.</exception>
        /// <exception cref="ObjectDisposedException">The context or connection have been disposed.</exception>
        /// <exception cref="InvalidOperationException">
        ///             Some error occurred attempting to process entities in the context either before or after sending commands
        ///             to the database.
        ///             </exception>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}