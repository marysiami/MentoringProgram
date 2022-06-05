using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(x => x.Orders.Select(x => x.Total).Sum() > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers.Select(y => (y, suppliers.Where(x => x.City == y.City && x.Country == y.Country)));
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            var groupedSuppliers = suppliers.GroupBy(x => new { x.City, x.Country }).Select(y => new
            {
                City = y.Key.City,
                Country = y.Key.Country,
                Suppliers = y.ToList()
            });

            return customers.Select(x =>
            {
                var matchingGroup = groupedSuppliers.FirstOrDefault(y => y.City == x.City && y.Country == x.Country)?.Suppliers;

                return (x, matchingGroup == null ? new List<Supplier>() : matchingGroup.AsEnumerable());
            });

        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(x => x.Orders.Length > 0 && x.Orders.Select(x => x.Total).Sum() > limit);          
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            return customers
                .Where(x => x.Orders.Count() > 0)
                .Select(x => (x, x.Orders.Select(y => y.OrderDate).Min()));
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            return customers
                .Where(x => x.Orders.Count() > 0)
                .Select(x => (x, x.Orders.Select(y => y.OrderDate).Min()))
                .OrderBy(x => x.Item2.Year)
                .ThenBy(x => x.Item2.Month)
                .ThenByDescending(x => x.x.Orders.Select(x => x.Total).Sum())
                .ThenBy(x => x.x.CompanyName);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            return customers.Where(x => Regex.IsMatch(x.PostalCode, @"[\D]")
            || string.IsNullOrEmpty(x.Region)
            || !Regex.IsMatch(x.Phone, @"[\(\+?]"));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            /* example of Linq7result

             category - Beverages
	            UnitsInStock - 39
		            price - 18.0000
		            price - 19.0000
	            UnitsInStock - 17
		            price - 18.0000
		            price - 19.0000
             */

            var group = products.GroupBy(x => new { x.Category }).Select(y => new
            {
                Category = y.Key.Category,
                UnitInStockGroups = y.GroupBy(z => z.UnitsInStock).Select(z => new
                {
                    UnitsInStock = z.Key,
                    Products = z.OrderBy(v => v.UnitPrice)
                })
            });

            var result = group.Select(x => new Linq7CategoryGroup()
            {
                Category = x.Category,
                UnitsInStockGroup = x.UnitInStockGroups.Select(z => new Linq7UnitsInStockGroup()
                {
                    UnitsInStock = z.UnitsInStock,
                    Prices = z.Products.Select(x => x.UnitPrice)
                })
            });

            return result;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
        IEnumerable<Product> products,
        decimal cheap,
        decimal middle,
        decimal expensive
    )
        {
            var categories = new decimal[] { cheap, middle, expensive };

            return products.GroupBy(x => categories.FirstOrDefault(y => x.UnitPrice <= y)).Select(x => (x.Key, x.AsEnumerable()));
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            var customersGroupedByCity = customers.GroupBy(x => x.City);

            var result = customersGroupedByCity.Select(x => (
            x.Key,
            (int)Math.Round(x.Average(y => y.Orders.Length == 0 ? 0 : y.Orders.Sum(z => z.Total))),
            (int)Math.Round(x.Average(y => y.Orders.Length))
            ));

            return result;
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            var countries = suppliers.Select(x => x.Country)
                .Distinct()
                .OrderBy(x => x.Length)
                .ThenBy(x => x);

            return String.Join("", countries);

        }
    }
}