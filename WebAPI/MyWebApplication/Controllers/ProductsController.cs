using Microsoft.AspNetCore.Mvc;
using MyWebApiApplication.Interfaces;
using MyWebApiApplication.Models;

namespace MyWebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository ProductRepository;
        public ProductsController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var model = ProductRepository.GetById(id);
            return new JsonResult(model);
        }

        [HttpGet]
        public JsonResult GetAll(int? pageNumber, int? pageSize, int? categoyId)
        {
            var model = ProductRepository.GetAll(pageNumber, pageSize, categoyId);
            return new JsonResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await ProductRepository.Create(product);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.ProductID)
            {
                return BadRequest();
            }

            await ProductRepository.Update(product);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = ProductRepository.GetById(id);
            if (product == null)
            {
                return BadRequest();
            }

            await ProductRepository.Delete(product);

            return Ok();
        }

    }
}
