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

            var element = from product in productLines
                          let elements = product.Split(';')
                          select elements;

            foreach (var line in element)
            {
                
                Console.WriteLine(line+"\n");
            }
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
