
using ConsoleApp;
using MyWebApiApplication.Models;

Console.WriteLine("----------- -----------  Categories ----------- ----------- ");

var categoryRequstGenerator = new CategoryRequestGenerator();

Console.WriteLine("----------- GET ALL");
Console.WriteLine(await categoryRequstGenerator.GetAllCategories());

Console.WriteLine("----------- GET ID = 2");
Console.WriteLine(await categoryRequstGenerator.GetCategoryById(2));


Console.WriteLine("----------- CREATE NEW CATEGORY");
Console.WriteLine(await categoryRequstGenerator.CreateCategory(
    new Category()
    {
        CategoryName = "New name 2",
        Description = "aaa"
    }
));

Console.WriteLine("----------- UPDATE ID = 222");
Console.WriteLine(await categoryRequstGenerator.UpdateCategory(222, 
    new Category() 
    { 
        CategoryID = 222,
        CategoryName= "New name",
        Description = "aaa"}
    )
);

Console.WriteLine("----------- DELETE ID = 222");
Console.WriteLine(await categoryRequstGenerator.DeleteCategory(222));




Console.WriteLine("----------- -----------  Products ----------- ----------- ");

var productRequstGenerator = new ProductRequestGenerator();

Console.WriteLine("----------- GET ALL");
Console.WriteLine(await productRequstGenerator.GetAllProducts());

Console.WriteLine("----------- GET ID = 2");
Console.WriteLine(await productRequstGenerator.GetProductById(2));

Console.WriteLine("----------- CREATE NEW PRODUCT");
Console.WriteLine(await productRequstGenerator.CreateProduct(
    new Product()
    {
        ProductName = "product test",
        Discontinued = true,
        QuantityPerUnit = "bbb",
        ReorderLevel = 2,
        CategoryID = 222,
        SupplierID = 1,
        UnitsInStock = 2,
        UnitPrice = 22,
        UnitsOnOrder = 21
    }
));

Console.WriteLine("----------- UPDATE ");
Console.WriteLine(await productRequstGenerator.UpdateProduct(2,
      new Product()
      {
          ProductID = 2,
          ProductName = "product test",
          Discontinued = true,
          QuantityPerUnit = "bbb",
          ReorderLevel = 2,
          CategoryID = 222,
          SupplierID = 1,
          UnitsInStock = 2,
          UnitPrice = 22,
          UnitsOnOrder = 21
      }
    )
);


Console.WriteLine("DELETE ID = 333");
Console.WriteLine(await productRequstGenerator.DeleteProduct(33333));