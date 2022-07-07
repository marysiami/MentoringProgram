using MyWebApplication.Interfaces;
using MyWebApplication.Models;

namespace MyWebApplication.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ILogger<CategoryRepository> Logger { get; set; }
        private MyDbContext _dbContext;

        public CategoryRepository(MyDbContext context, ILogger<CategoryRepository> logger)
        {
            _dbContext = context;
            Logger = logger;
        }

        public List<Category> GetAll()
        {
            var result = new List<Category>();
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
                Logger.LogError(ex, "Exception during GetAllCategories");
            }

            return result;
        }
    }
}
