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

var newOrder = new Order()
{
    CreatedDate = DateTime.Now,
    UpdatedDate = DateTime.Now,
    ProductId = 3,
    Status = "OK"
};

//await orderRepository.Insert(newOrder);
//await orderRepository.Insert(newOrder);
//await orderRepository.Insert(newOrder);

//newOrder.CreatedDate = DateTime.Now.AddDays(-100);
//newOrder.Status = "Error";
//newOrder.Id = 1;

//await orderRepository.Update(newOrder);

//var orderDataSet = orderRepository.Get(1);
//Console.WriteLine(orderDataSet.Tables.Count);

//var orderDataEmpty = orderRepository.GetAll("OK", DateTime.Now.AddDays(-100), DateTime.Now, 1);
//var orderDataFull = orderRepository.GetAll("OK", DateTime.Now.AddDays(-100), DateTime.Now, 3);

await orderRepository.Delete("OK", DateTime.Now.AddDays(-100), DateTime.Now, 3);

#endregion