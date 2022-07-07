using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Interfaces;
using MyWebApplication.Models;

namespace MyWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService ProductService { get; set; }
        public ProductsController(IProductService productService)
        {
            ProductService = productService;            
        }

        public IActionResult Index()
        {
            var allProducts = ProductService.GetProducts();
          
            return View(allProducts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var newViewModel = ProductService.GetEmptyProductViewModel();

            return View(newViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product)
        {
            await ProductService.CreateNewProduct(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var newViewModel = ProductService.GetEditProductViewModel(id);

            return View(newViewModel);
        }

        [HttpPost]
        public IActionResult Save(ProductViewModel product)
        {
            ProductService.UpdateProduct(product);

            return RedirectToAction("Index");
        }
    }
}
