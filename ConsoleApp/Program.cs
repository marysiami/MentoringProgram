using ADOLibrary.Repositories;
using ADOLibrary.Models;

#region product
var productRepository = new ProductRepository();

//var productList = productRepository.GetAll();
//var product = productRepository.Get(1);

//var newProduct = new Product()
//{
//    Name = "Product5",
//    Description = "aaaa5",
//    Length = 11,
//    Weight = 22,
//    Width = 33
//};
//await productRepository.Insert(newProduct);

//newProduct.Id = 2;
//newProduct.Name = "Product5.1";
//newProduct.Description = "aaaa5.1";

//await productRepository.Update(newProduct);
//await productRepository.Delete(1);
//await productRepository.DeleteAll();

#endregion

#region order
var orderRepository = new OrderRepository();

#endregion