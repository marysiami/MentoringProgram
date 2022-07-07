using Microsoft.EntityFrameworkCore;
using MyWebApiApplication.Models;

namespace MyWebApiApplication
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)       
        {
           
        }
    }
}
