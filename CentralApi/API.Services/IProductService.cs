using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities.Filter;

namespace API.Services
{
    public interface IProductService
    {
        Task<List<ProductEntity>> GetProducts(Options listOptions);
        List<ProductEntity> GetProducts();
    }
}