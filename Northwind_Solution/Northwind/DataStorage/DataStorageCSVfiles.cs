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

            var qry = from line in productLines.Skip(1)
                      let elements = line.Split(';')
                      select new String[]{ elements[1], elements[4], elements[5], elements[6], elements[7], elements[8], elements[9] };

            var listOfElements = qry.ToList();

            foreach (var element in listOfElements)
            {
                Product p = new Product(
                    element[0],
                    element[1],
                    Convert.ToDecimal(element[2]),
                    Convert.ToInt16(element[3]),
                    Convert.ToInt16(element[4]),
                    Convert.ToInt16(element[5]),
                    false
                    );

                if(Convert.ToInt16(element[6]) == -1)
                {
                    p.discontinued = true;
                } else
                {
                    p.discontinued = false;
                }

                products.Add(p);
            }

            return products;
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
