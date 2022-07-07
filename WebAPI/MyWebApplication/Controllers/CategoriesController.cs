using Microsoft.AspNetCore.Mvc;
using MyWebApiApplication.Interfaces;
using MyWebApiApplication.Models;

namespace MyWebApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository CategoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var model = CategoryRepository.GetById(id);
            return new JsonResult(model);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var model = CategoryRepository.GetAll();
            return new JsonResult(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            await CategoryRepository.Create(category);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if( id != category.CategoryID)
            {
                return BadRequest();
            }

            await CategoryRepository.Update(category);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = CategoryRepository.GetById(id);
            if(category == null)
            {
                return BadRequest();
            }

            await CategoryRepository.Delete(category);

            return Ok();
        }

    }
}
