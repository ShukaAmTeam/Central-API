using System;
using API.Data.DataAccess;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.UnitOfWork
{
    public interface ICentralDbUoW : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, ICentralEntity;
        int Complete();
    }
}