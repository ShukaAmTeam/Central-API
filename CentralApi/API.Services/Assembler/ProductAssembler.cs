using API.Data.DataAccess.Repositories.EF;
using API.Entities;

namespace API.Services.Assembler
{
    public class ProductAssembler : Assembler<ProductEntity, Products>
    {
        public override ProductEntity DomainEntityToDto(Products productDomainEntity)
        {
            var productEntity = new ProductEntity
            {
                Name = productDomainEntity.Name,
                //AvailableCount = productDomainEntity.AvailableCount,
                //CostPrice = productDomainEntity.CostPrice,
                Description = productDomainEntity.Description,
                //IsAvailable = productDomainEntity.IsAvailable,
                //MeasUnits = productDomainEntity.MeasUnits,
                //Price = productDomainEntity.Price,
                //ProductTypes = productDomainEntity.ProductTypes,
                //TotalCount = productDomainEntity.TotalCount
            };

            return productEntity;
        }

        public override Products DtoToDomainEntity(ProductEntity dto)
        {
            return new Products();
        }
    }
}