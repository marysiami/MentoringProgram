using MyWebApplication.Models;

namespace MyWebApplication.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
