using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class ProductService
    {
         Task<MetaDataListEntity<ProductEntity>> GetProducts(ListOptionsEntity listOptions);

        Task<List<object>> GetProducts();

    }
}