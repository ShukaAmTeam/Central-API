using System.Linq;

namespace API.Data.DataAccess
{
    public interface ICentralDbRepository<TEntity>
    {
        IQueryable<TEntity> Items { get; }
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}