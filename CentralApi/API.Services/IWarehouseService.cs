using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Entities.Filter;

namespace API.Services
{
    public interface IWarehouseService
    {
        Task<List<WarehouseEntity>> GetWarehouseEntities();
        Task<List<WarehouseEntity>> GetWarehouseEntities(IEntityFilter<WarehouseEntity> filter);
    }
}