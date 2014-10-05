using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Model;

namespace Northwind.DataStorage
{
    class DataStorageCSVfiles : IDataStorage
    {
        private string _DataFolder = @"northwind_csv_data\";
        public IList<Product> Products()
        {
            IList<Product> products = new List<Product>();
            string[] productLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/products.csv");
            string[] categoryLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/categories.csv");

            var qry = from line in productLines
                      let elements = line.Split(';')
                      select new Product()
                      {
                          name = elements[1],
                          quantityPerUnit = elements[4],
                          unitPrice = elements[5],
                          unitsInStock = elements[6],
                          unitsOnOrder = elements[7],
                          reorderLevel = elements[8]
                      };

            var test = qry.ToList();

            foreach (var line in test.Skip(1))
            {
                Console.WriteLine(line.name);
            }

            Console.ReadKey();
            return null;
        }

        public IList<Product> Categories()
        {
            throw new NotImplementedException();
        }

        public IList<Order> Orders()
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
