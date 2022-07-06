using ORMLibrary.Models;

namespace ORMLibrary.Interfaces
{
    public interface IProductRepository
    {
        public Task Insert(Product product);
        public void Update(Product product);
        public Product? Get(int id);
        public List<Product> GetAll();
        public void Delete(int id);
        public void DeleteAll();
    }
}
