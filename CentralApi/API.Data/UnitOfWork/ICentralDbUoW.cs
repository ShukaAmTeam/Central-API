using System;
using API.Data.DataAccess;

namespace API.Data.UnitOfWork
{
    public interface ICentralDbUoW : IDisposable
    {
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        int Complete();
    }
}