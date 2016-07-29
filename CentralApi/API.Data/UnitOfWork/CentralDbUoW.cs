using System;
using System.Linq;
using API.Data.DataAccess;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using API.Data.DataAccess.Repositories;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.UnitOfWork
{
    public class CentralDbUoW<TContext> : ICentralDbUoW, IDisposable where TContext : CentralDb, new()
    {
        private readonly CentralDb _context;
        private readonly Dictionary<Type, object> _repositories;
        
        public CentralDbUoW() : this(new TContext()) { }
      
        public CentralDbUoW(CentralDb context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, ICentralEntity
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;

            var repository = new Repository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

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
        /// <exception cref="DbUpdateException">An error occurred sending updates to the database.</exception>
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            foreach (var disposableRepository in _repositories.Select(repository => repository.Value as IDisposable))
            {
                disposableRepository?.Dispose();
            }
            _context.Dispose();

            GC.SuppressFinalize(this);  //  ToDo ?
        }
    }
}