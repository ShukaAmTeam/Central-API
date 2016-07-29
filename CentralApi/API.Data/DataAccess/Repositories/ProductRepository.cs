using API.Data.DataAccess.Repositories.EF;
using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;

namespace API.Data.DataAccess.Repositories
{
    public class ProductRepository<TEntity> : IDisposable, IProductRepository<TEntity> where TEntity : class
    {
        //private readonly ProductEntities _dbContext;
        //private bool _disposed;

        //public EngineRepository(EngineEntities dbContext)
        //{
        //    if (dbContext == null) throw new ArgumentNullException("dbContext");
        //    {
        //        _dbContext = dbContext;
        //    }
        //}

        //protected EngineEntities DbContext
        //{
        //    get { return _dbContext; }
        //}

        //public IQueryable<TEntity> Items => _dbContext.Set<TEntity>();

        //public void Create(TEntity entity)
        //{
        //    if (entity == null) throw new ArgumentNullException("entity");
        //    DbContext.Set<TEntity>().Add(entity);
        //}

        //public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        //{
        //    return _dbContext.Set<TEntity>().Where(filter);
        //}

        //public TEntity GetById(int id)
        //{
        //    return _dbContext.Set<TEntity>().Find(id);
        //}

        //public void Delete(TEntity entity)
        //{
        //    if (entity == null) throw new ArgumentNullException("entity");
        //    DbContext.Set<TEntity>().Attach(entity);
        //    DbContext.Set<TEntity>().Remove(entity);
        //}

        //public void Update(TEntity entity)
        //{
        //    if (entity == null) throw new ArgumentNullException("entity");
        //    DbContext.Set<TEntity>().Attach(entity);
        //    DbContext.Entry(entity).State = EntityState.Modified;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (_disposed) return;

        //    if (disposing)
        //    {
        //        _dbContext.Dispose();
        //    }

        //    _disposed = true;
        //}
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
