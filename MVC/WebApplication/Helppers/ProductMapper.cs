using MyWebApplication.Models;

namespace MyWebApplication.Helppers
{
    public static class ProductMapper
    {
        public static Product ConvertToProduct(ProductViewModel viewModel)
        {
            var result = new Product()
            {
                ProductID = viewModel.ProductID,
                ProductName = viewModel.ProductName,
                SupplierID = viewModel.SupplierID,
                CategoryID = viewModel.CategoryID,
                QuantityPerUnit = viewModel.QuantityPerUnit,
                UnitPrice = viewModel.UnitPrice,
                UnitsInStock = viewModel.UnitsInStock,
                UnitsOnOrder = viewModel.UnitsOnOrder,
                ReorderLevel = viewModel.ReorderLevel,
                Discontinued = viewModel.Discontinued
            };
            return result;
        }

        public static ProductViewModel ConvertToViewModel(Product product)
        {
            var result = new ProductViewModel()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                SupplierID = product.SupplierID,
                CategoryID = product.CategoryID,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPriceStr = product.UnitPrice.ToString(),                
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            };
            return result;
        }
    }
}
