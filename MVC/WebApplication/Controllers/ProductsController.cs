using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Interfaces;

namespace MyWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository ProductRepository { get; set; }
        public ProductsController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public IActionResult Index()
        {
            var allProducts = ProductRepository.GetAll();
            return View(allProducts);
        }
    }
}
