using MyWebApplication.Interfaces;
using MyWebApplication.Models;

namespace MyWebApplication.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyDbContext _dbContext;
        public CategoryRepository(MyDbContext context)
        {
            _dbContext = context;
        }

        public List<Category> GetAll()
        {
            var result = new List<Category>();
            using (_dbContext)
            {
                try
                {
                    var query = from category in _dbContext.Categories
                                select new
                                {
                                    categoryID = category.CategoryID,
                                    categoryName = category.CategoryName,
                                    description = category.Description
                                };

                    foreach (var categoryInfo in query)
                    {
                        result.Add(new Category()
                        {
                            CategoryID = categoryInfo.categoryID,
                            CategoryName = categoryInfo.categoryName,
                            Description = categoryInfo.description
                        });
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

                return result;
            }
        }
    }
}
