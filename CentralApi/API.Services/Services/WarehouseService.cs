using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DataAccess;
using API.Data.DataAccess.Repositories.EF;
using API.Data.UnitOfWork;
using API.Entities;
using API.Entities.Filtering;
using API.Services.Assembler;

namespace API.Services.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly ICentralDbUoW _centralDbUoW;
        private readonly IRepository<Warehouse> _warehouseRepository;
        private readonly Assembler<Warehouse, WarehouseEntity> _assembler;

        public WarehouseService()
        {
            _centralDbUoW = new CentralDbUoW<CentralDb>();
            _warehouseRepository = _centralDbUoW.GetRepository<Warehouse>();
        }
        public async Task<List<WarehouseEntity>> GetWarehouseEntities()
        {
            return _warehouseRepository.GetAll()
                .Select(item=>_assembler.DtoToDomainEntity(item))
                .ToList();
        }

        public async Task<List<WarehouseEntity>> GetWarehouseEntities(IEntityFilter<WarehouseEntity> filter)
        {
            return filter.Filer(_warehouseRepository.GetAll()
                .Select(item => _assembler.DtoToDomainEntity(item))).ToList();
        }
    }
}