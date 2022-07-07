using MyWebApplication.Configuration;
using MyWebApplication.Helppers;
using MyWebApplication.Interfaces;
using MyWebApplication.Models;

namespace MyWebApplication.Services
{
    public class ProductService : IProductService
    {
        private int ItemsPerPage;
        private ICategoryRepository CategoryRepository { get; set; }
        private IProductRepository ProductRepository { get; set; }
        private ISupplierRepository SupplierRepository { get; set; }
        private ILogger<ProductService> Logger { get; set; }
        
        public ProductService(ICategoryRepository categoryRepository,
            ISupplierRepository supplierRepository,
            IProductRepository productRepository,
            ProductPageConfiguration pageConfiguration,
            ILogger<ProductService> logger)
        {
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
            SupplierRepository = supplierRepository;
            ItemsPerPage = pageConfiguration.ItemsPerPage;
            Logger = logger;
        }

        public NewProductViewModel GetEmptyProductViewModel()
        {
            var model = new NewProductViewModel
            {
                Suppliers = SupplierRepository.GetAll(),
                Categories = CategoryRepository.GetAll()
            };

            return model;
        }

        public List<ListProductViewModel> GetProducts()
        {
            return ProductRepository.GetAll(ItemsPerPage);
        }

        public async Task CreateNewProduct(ProductViewModel viewModel)
        {
            try
            {
                var product = ProductMapper.ConvertToProduct(viewModel);
                await ProductRepository.Insert(product);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Exception during CreateNewProduct");
            }           
        }

        public void UpdateProduct(ProductViewModel viewModel)
        {
            try
            {
                var product = ProductMapper.ConvertToProduct(viewModel);
                ProductRepository.Update(product);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Exception during UpdateProduct");
            }
        }

        public EditProductViewModel GetEditProductViewModel(int id)
        {
            var product = ProductRepository.Get(id) ?? new Product();
            if (product == null)
            {
                Logger.LogError("GetEditProductViewModel product is null");
            }
            
            var productViewModel = ProductMapper.ConvertToViewModel(product);
            var model = new EditProductViewModel
            {
                Product = productViewModel,
                Suppliers = SupplierRepository.GetAll(),
                Categories = CategoryRepository.GetAll()
            };

            return model;
        }
    }
}
