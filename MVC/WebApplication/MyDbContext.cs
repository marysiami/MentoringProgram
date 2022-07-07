using Microsoft.EntityFrameworkCore;
using MyWebApplication.Models;

namespace MyWebApplication
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)       
        {
           
        }

    }
}
