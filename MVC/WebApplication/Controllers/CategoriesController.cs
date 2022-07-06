using Microsoft.AspNetCore.Mvc;

namespace MyWebApplication.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
