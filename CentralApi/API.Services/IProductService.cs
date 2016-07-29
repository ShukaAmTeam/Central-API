namespace API.Services
{
    public interface IProductService
    {
         Task<MetaDataListEntity<ProductEntity>> GetProducts(ListOptionsEntity listOptions);

    }
}