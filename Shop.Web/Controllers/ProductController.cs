using System.Web.Http;
using Shop.Business.Infrastructure;
using Shop.Business.Interfaces;

namespace Shop.Web.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch (ValidationException e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}
