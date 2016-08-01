using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DataAccess;
using API.Data.DataAccess.Repositories.EF;
using API.Entities;
using API.Entities.Filter;
using API.Data.UnitOfWork;
using API.Services.Assembler;

namespace API.Services.Services
{
    public class ProductService : IProductService, IDisposable
    {
        private readonly ICentralDbUoW _centralDbUoW;
        private readonly IRepository<Products> _productRepository;

        public ProductService()
        {
            _centralDbUoW = new CentralDbUoW<CentralDb>();
            _productRepository = _centralDbUoW.GetRepository<Products>();
            var r = _centralDbUoW.GetRepository<Warehouse>();
        }

        public async Task<List<ProductEntity>> GetProducts(Options listOptions)
        {
            var products = _productRepository.GetAll();

            var productAssembler = new ProductAssembler();
            var agentSlotEntities = productAssembler.DomainEntitiesToDtos(products);

            return agentSlotEntities;
        }
        public List<ProductEntity> GetProducts()
        {
            var products = _productRepository.GetAll();

            var productAssembler = new ProductAssembler();
            var agentSlotEntities = productAssembler.DomainEntitiesToDtos(products);

            return agentSlotEntities;
        }

        public void Dispose()
        {
            _centralDbUoW.Dispose();
        }
    }
}