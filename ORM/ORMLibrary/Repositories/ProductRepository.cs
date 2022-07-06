using ORMLibrary.Interfaces;
using ORMLibrary.Models;

namespace ORMLibrary.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyContext db;
        public ProductRepository(MyContext context)
        {
            db = context;
        }
        public void Delete(int id)
        {
            var product = Get(id);
            if(product != null)
            {
                db.Products.Remove(product);
                SaveChanges();
            }
            else
            {
                throw new Exception("No Product for ID");
            }

        }

        public void DeleteAll()
        {
            var list = GetAll();
            db.Remove(list);
            SaveChanges();
        }

        public Product? Get(int id)
        {
            var result = db.Products
                .Where(b => b.Id == id)
                .FirstOrDefault();
            return result;
        }

        public List<Product> GetAll()
        {
            var result = db.Products.ToList();
            return result;
        }

        public async Task Insert(Product product)
        {
            if (product == null)
            {
                throw new Exception("Product is null");
            }
            await db.Products.AddAsync(product);
            SaveChanges();
        }

        public void Update(Product product)
        {
            if (product == null)
            {
                throw new Exception("Product is null");
            }

            db.Products.Update(product);
            SaveChanges();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }        
    }
}
