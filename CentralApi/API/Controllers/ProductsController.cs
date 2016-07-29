using API.Entities.Filter;
using API.Services;
using API.Services.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private readonly IProductService _productsService;

        public ProductsController()
        {
            _productsService = new ProductService();// productsService;
        }
        public ProductsController(IProductService productsService)
        {
            _productsService =new ProductService();// productsService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetProducts(int? limit = null, int? offset = null)
        {
            var productsEntity2 =  _productsService.GetProducts();
            var productsEntity = await _productsService.GetProducts(new Options(limit, offset)).ConfigureAwait(false);

            //var productsModel = new ProductsModel
            //{
            //    Products = new List<Products>(),
            //    Metadata = new MetaData
            //    {
            //        TotalCount = agentSlotsEntity.TotalCount,
            //        Limit = agentSlotsEntity.Limit,
            //        Offset = agentSlotsEntity.Offset
            //    }
            //};

            //foreach (var agentSlot in from agentSlotEntity in productsEntity.DataList select AgentSlot.MapFromEntity(agentSlotEntity))
            //{
            //    //remove agent from application child records
            //    foreach (var application in agentSlot.Applications)
            //    {
            //        application.AgentSlot = null;
            //    }

            //    productsModel.Products.Add(agentSlot);
            //}

            //return Ok(productsModel);
            return Ok(productsEntity);
        }


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}