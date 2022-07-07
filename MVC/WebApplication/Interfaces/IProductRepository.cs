using MyWebApplication.Models;

namespace MyWebApplication.Interfaces
{
    public interface IProductRepository
    {
        List<ListProductViewModel> GetAll(int limit);
        Task Insert(Product product);
        void Update(Product product);
        Product? Get(int id);
    }
}
