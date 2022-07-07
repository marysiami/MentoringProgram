using MyWebApiApplication.Models;

namespace MyWebApiApplication.Interfaces
{
    public interface IProductRepository
    {
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
        Product GetById(int id);
        List<Product> GetAll(int? pageNumber, int? pageSize, int? categoyId);
    }
}
