using System;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using API.Data.Filtering;

namespace API.Data.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;

        /// <exception cref="ArgumentNullException"><paramref name="dbContext"/> is <see langword="null" />.</exception>
        public Repository(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));

            _dbContext = dbContext;
        }

        protected DbContext DbContext => _dbContext;

        public IQueryable<TEntity> Items => _dbContext.Set<TEntity>();

        /// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
        public void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            DbContext.Set<TEntity>().Add(entity);
        }

        /// <exception cref="ArgumentNullException"><paramref name="entities"/> is <see langword="null" />.</exception>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            DbContext.Set<TEntity>().AddRange(entities);
        }

        /// <exception cref="InvalidOperationException">Thrown if the context has been disposed.</exception>
        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        /// <exception cref="ArgumentNullException"><paramref name="source" /> is null.</exception>
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();//.ToList(); //ToDo change to .AsEnumerable()
        }

        /// <exception cref="ArgumentNullException"><paramref name="source" /> or <paramref name="predicate" /> is null.</exception>
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        /// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
        public void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
        }

        /// <exception cref="ArgumentNullException"><paramref name="entities"/> is <see langword="null" />.</exception>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities) //ToDo check
            {
                DbContext.Set<TEntity>().Attach(entity);
            }
            DbContext.Set<TEntity>().RemoveRange(entities);
        }
        
        /// <exception cref="ArgumentNullException"><paramref name="entity"/> is <see langword="null" />.</exception>
        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}