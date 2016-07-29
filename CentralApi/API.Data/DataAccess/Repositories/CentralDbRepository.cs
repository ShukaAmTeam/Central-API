using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess.Repositories
{
    public class CentralDbRepository<TEntity> : IDisposable, ICentralDbRepository<TEntity> where TEntity : class
    {
        private readonly CentralDbEntities _dbContext;
        private bool _disposed;

        public CentralDbRepository(CentralDbEntities dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
            {
                _dbContext = dbContext;
            }
        }

        protected CentralDbEntities DbContext
        {
            get { return _dbContext; }
        }

        public IQueryable<TEntity> Items => _dbContext.Set<TEntity>();

        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>().Where(filter);
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}
