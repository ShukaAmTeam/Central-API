using System;
using API.Data.DataAccess.Repositories.EF;

namespace API.Data.DataAccess
{
    public interface IProductRepository:IDisposable, IRepository<Product>
    {
         
    }
}