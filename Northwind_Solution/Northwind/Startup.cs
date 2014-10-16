using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataStorage;
using Northwind.Model;

namespace Northwind
{
    class Startup
    {
        /// <summary>
        /// The main which shows that we fulfill the part 3 assignment 40.1 Here the data storage is using the csv file.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            NorthwindController northwindController = new NorthwindController(new DataStorageDB());

            northwindController.Subscribe((o, order) => Console.WriteLine(order));
            northwindController.AddOrder(null,DateTime.Now,null,100,"SickShip","SickAddress","SickCity","SickRegion","SickPC","SuckCountry");

            Print5FirstProducts(northwindController);
            ShippingCountriesInOrder(northwindController);
        }

        /// <summary>
        /// The main which shows that we fulfill the part 2 assignment 40.1 Here the data storage is using the csv file.
        /// </summary>
        /// <param name="args"></param>
        private static void MainCSV(string[] args)
        {
            NorthwindController northwindController = new NorthwindController(new DataStorageCSVfiles());

            northwindController.Subscribe((o, order) => Console.WriteLine(order));
            northwindController.AddOrder(null, DateTime.Now, null, 100, "SickShip", "SickAddress", "SickCity",
                "SickRegion", "SickPC", "SuckCountry");

            Print5FirstProducts(northwindController);
            ShippingCountriesInOrder(northwindController);
        }

        private static void Print5FirstProducts(NorthwindController northwindController)
        {
            //Write a list with the name of the first 5 products [use LINQ]
            var products = northwindController._products;
            var productNames = (from product in products
                                let name = product.ProductName
                                select name).Take(5);

            Console.WriteLine("Name of the first 5 products:");
            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }
        }

        private static void ShippingCountriesInOrder(NorthwindController northwindController)
        {
            //Write the counting of orders by shipping country. Order the output by descending count [use LINQ]
            var orders = northwindController._orders;

            var groups = from order in orders
                         group order by order.ShipCountry into g
                         select g;

            var countings = from g in groups
                            orderby g.Count() descending
                            select new { Country = g.Key, NumberOfCountryOrders = g.Count() };

            Console.WriteLine("\n\nCounting of orders by shipping country:\n");
            foreach (var count in countings)
            {
                Console.WriteLine("Country: " + count.Country + "\nOrders by shipping country: " + count.NumberOfCountryOrders + "\n");
            }
        }

    }
}
