using MyWebApplication.Interfaces;
using MyWebApplication.Models;

namespace MyWebApplication.Repositories
{
    public class ProductRepository : IProductRepository
    {        
        private MyDbContext _dbContext;
        public ProductRepository(MyDbContext context)
        {
            _dbContext = context;
        }
        public List<ListProductViewModel> GetAll(int limit)
        {           
            var result = new List<ListProductViewModel>();
            
            var products = (from p in _dbContext.Products
                            join c in _dbContext.Categories
                            on p.CategoryID equals c.CategoryID
                            join s in _dbContext.Suppliers
                            on p.SupplierID equals s.SupplierID
                            select new
                            {
                                ProductID = p.ProductID,
                                ProductName = p.ProductName,
                                QuantityPerUnit = p.QuantityPerUnit,
                                UnitPrice = p.UnitPrice,
                                UnitsInStock = p.UnitsInStock,
                                UnitsOnOrder = p.UnitsOnOrder,
                                ReorderLevel = p.ReorderLevel,
                                Discontinued = p.Discontinued,
                                CategoryName = c.CategoryName,
                                SupplierName = s.CompanyName
                            });
                    
            if (limit > 0)
            {
                products = products.Take(limit);
            }                   

            foreach (var productInfo in products)
            {
                result.Add(new ListProductViewModel()
                {
                    ProductID = productInfo.ProductID,
                    ProductName = productInfo.ProductName,
                    QuantityPerUnit = productInfo.QuantityPerUnit,
                    UnitPrice = productInfo.UnitPrice,
                    UnitsInStock = productInfo.UnitsInStock,
                    UnitsOnOrder = productInfo.UnitsOnOrder,
                    ReorderLevel = productInfo.ReorderLevel,
                    Discontinued = productInfo.Discontinued,
                    CategoryName = productInfo.CategoryName,
                    SupplierName = productInfo.SupplierName
                });
            }           

            return result;           
        }

        public async Task Insert(Product product)
        {           
           await _dbContext.Products.AddAsync(product);
           _dbContext.SaveChanges();
        }

        public void Update(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public Product? Get(int id)
        {           
            return _dbContext.Products.FirstOrDefault(x => x.ProductID == id);
        }
    }
}
