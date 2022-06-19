using ADOLibrary.Models;
using System.Data;

namespace ADOLibrary.Interfaces
{
    public interface IProductRepository
    {
        public Task Insert(Product product);
        public Task Update(Product product);
        public DataSet Get(int id);
        public List<Product> GetAll();
        public Task Delete(int id);
        public Task DeleteAll();
    }
}
