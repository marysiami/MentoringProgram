﻿using System.Globalization;

namespace MyWebApplication.Models
{
    public class ProductViewModel
    {  
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice => decimal.Parse(UnitPriceStr, CultureInfo.InvariantCulture);
        public string UnitPriceStr { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
