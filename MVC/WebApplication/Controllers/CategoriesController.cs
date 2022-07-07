using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Interfaces;

namespace MyWebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryRepository CategoryRepository { get; set; }
        public CategoriesController(ICategoryRepository categoryRepository)
        {   
            CategoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var allCategories = CategoryRepository.GetAll();
            return View(allCategories);
        }
    }
}
