using API.Data.DataAccess.Repositories.EF;
using API.Entities;

namespace API.Services.Assembler
{
    public class ProductAssembler : Assembler<ProductEntity, Products>
    {
        public override ProductEntity DomainEntityToDto(Products productDomainEntity)
        {
            return new ProductEntity();
        }

        public override Products DtoToDomainEntity(ProductEntity dto)
        {
            return new Products();
        }
    }
}