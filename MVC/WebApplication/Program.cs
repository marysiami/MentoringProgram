using Microsoft.EntityFrameworkCore;
using MyWebApplication;
using MyWebApplication.Interfaces;
using MyWebApplication.Repositories;

var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = configuration.GetConnectionString("Northwind");
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
