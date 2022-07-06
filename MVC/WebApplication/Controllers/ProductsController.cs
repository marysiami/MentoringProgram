using Microsoft.AspNetCore.Mvc;

namespace MyWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
