using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Configuration;
using MyWebApplication.Interfaces;

namespace MyWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private int ItemsPerPage;
        private IProductRepository ProductRepository { get; set; }
        public ProductsController(IProductRepository productRepository, ProductPageConfiguration pageConfiguration)
        {
            ProductRepository = productRepository;
            ItemsPerPage = pageConfiguration.ItemsPerPage;
        }

        public IActionResult Index()
        {
            var allProducts = ProductRepository.GetAll(ItemsPerPage);
          
            return View(allProducts);
        }
    }
}
