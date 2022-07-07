using MyWebApiApplication.Interfaces;
using MyWebApiApplication.Models;

namespace MyWebApiApplication.Repositories
{
    public class ProductRepository : IProductRepository
    {        
        private MyDbContext _dbContext;
        public ProductRepository(MyDbContext context)
        {
            _dbContext = context;
        }
        public List<Product> GetAll()
        {           
            var result = new List<Product>();
            
            var products = (from p in _dbContext.Products
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
                                CategoryID = p.CategoryID,
                                SupplierID = p.SupplierID
                            });                    
        
            foreach (var productInfo in products)
            {
                result.Add(new Product()
                {
                    ProductID = productInfo.ProductID,
                    ProductName = productInfo.ProductName,
                    QuantityPerUnit = productInfo.QuantityPerUnit,
                    UnitPrice = productInfo.UnitPrice,
                    UnitsInStock = productInfo.UnitsInStock,
                    UnitsOnOrder = productInfo.UnitsOnOrder,
                    ReorderLevel = productInfo.ReorderLevel,
                    Discontinued = productInfo.Discontinued,
                    CategoryID = productInfo.CategoryID,
                    SupplierID = productInfo.SupplierID
                });
            } 
            return result;           
        }

        public async Task Insert(Product product)
        {           
           await _dbContext.Products.AddAsync(product);
           _dbContext.SaveChanges();
        }

        public async Task Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.ProductID == id);
        }
    }
}
