using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataStorage;

namespace Northwind
{
    class Startup
    {
        static void Main(string[] args)
        {
            NorthwindController northwindController = new NorthwindController(new DataStorageCSVfiles());

            northwindController.Subscribe((o, order) => Console.WriteLine(order));

            //Write a list with the name of the first 5 products [use LINQ]
            var products = northwindController._products;
            var productNames = (from product in products
                                let name = product._name
                                select name).Take(5);

            Console.WriteLine("Name of the first 5 products:");
            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }

            //Write the counting of orders by shipping country. Order the output by descending count [use LINQ]
            var orders = northwindController._orders;

            var groups = from order in orders
                         group order by order._shipCountry into g
                         select g;

            var countings = from g in groups
                                     orderby g.Count() descending
                                     select new { Country = g.Key, NumberOfCountryOrders = g.Count()};

            Console.WriteLine("\n\nCounting of orders by shipping country:\n");
            foreach (var count in countings)
            {
                Console.WriteLine("Country: " + count.Country + "\nOrders by shipping country: " + count.NumberOfCountryOrders + "\n");
            }

            Console.ReadKey();
        }

    }
}
