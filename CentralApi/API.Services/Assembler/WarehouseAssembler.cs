using System;
using API.Data.DataAccess.Repositories.EF;
using API.Entities;

namespace API.Services.Assembler
{
    public class WarehouseAssembler : Assembler<Warehouse, WarehouseEntity>
    {
        public override Warehouse DomainEntityToDto(WarehouseEntity tenancyDomainEntity)
        {
            throw new NotImplementedException();
        }

        public override WarehouseEntity DtoToDomainEntity(Warehouse dto)
        {
            var warehouseEntity = new WarehouseEntity()
            {
                Id = dto.Id,
                //Products = dto.Products,
                AdditionalInformation = dto.AdditionalInformation,
                DateCreated = dto.DateCreated,
                DateModified = dto.DateModified,
                IsAvalable = dto.IsAvalable,
                Quantity = dto.Quantity,
                QuantityAvalable = dto.QuantityAvalable,
            };
            warehouseEntity.Products = new ProductEntity()
            {
                Name = dto.Products.Name,
                Description = dto.Products.Description,
                //CostPrice = dto.Products.,

            };

            return warehouseEntity;
        }
    }
}