using MyWebApiApplication.Models;

namespace MyWebApiApplication.Interfaces
{
    public interface ICategoryRepository
    {
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(Category category);
        Category GetById(int id);
        List<Category> GetAll();
    }
}
