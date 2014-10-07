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
    internal class DataStorageCSVfiles : IDataStorage
    {
        public IList<Product> Products()
        {
            IList<Category> categories = new List<Category>();
            string[] productLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/products.csv");
            string[] categoryLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/categories.csv");

            var categoryQuery = from line in categoryLines.Skip(1)
                let elements = line.Split(';')
                select new Category(Int32.Parse(elements[0]), elements[1], elements[2], "");

            var listOfCategories = categoryQuery.ToList();

            var productQuery = from line in productLines.Skip(1)
                let elements = line.Split(';')
                let id = Int32.Parse(elements[0])
                let name = elements[1]
                let category = findCategory(listOfCategories,Int32.Parse(elements[3]))
                let quantityPerUnit = elements[4]
                let unitPrice = decimal.Parse(elements[5])
                let unitsInStock = Int32.Parse(elements[6])
                let unitsOnOrder = Int32.Parse(elements[7])
                let reorderLevel = Int32.Parse(elements[8])
                let discontinued = isDiscontinued(Int32.Parse(elements[9]))
                select
                    new Product(id, name, category, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel,
                        discontinued);

            //Console.WriteLine("Categories:");
            //foreach (var category in listOfCategories)
            //{
            //    Console.WriteLine(category);
            //}
            //Console.WriteLine("\n\n\nProducts:");
            //foreach (var product in productQuery)
            //{
            //    Console.WriteLine(product);
            //}

            return productQuery.ToList();
        }

        private bool isDiscontinued(int i)
        {
            if (i == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Category findCategory(IList<Category> categories, int ID)
        {
            foreach (var category in categories)
            {
                if (category.id == ID)
                {
                    return category;
                }
            }
            return null;
        }

        public IList<Category> Categories(int ID)
        {
            string[] categoryLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/categories.csv");

            var categoryQuery = from line in categoryLines.Skip(1)
                                let elements = line.Split(';')
                                where Int32.Parse(elements[0]) == ID
                                select new Category(Int32.Parse(elements[0]), elements[1], elements[2], "");

            return categoryQuery.ToList();
        }

        public IList<Order> Orders()
        {
            IList<Product> products = Products();

            IList<Order> orders = new List<Order>();
            IList<Order_Details> orderDetails = new List<Order_Details>();
            string[] orderLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/orders.csv");
            string[] orderDetailLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/order_details.csv");

            var odqry = from line in orderDetailLines.Skip(1)
                let elements = line.Split(';')
                select new String[] {elements[0], elements[1], elements[2], elements[3], elements[4]};

            var listOfOrderDetails = odqry.ToList();
            foreach (var element in listOfOrderDetails)
            {
                Order_Details od = new Order_Details(
                    Convert.ToInt16(element[0]),
                    null,
                    Convert.ToDecimal(element[2]),
                    Convert.ToInt16(element[3]),
                    0
                    );

                if (element[4].Contains("E"))
                {
                    decimal d = decimal.Parse(element[4], System.Globalization.NumberStyles.Any);
                    od.Discount = d;
                }
                else
                {
                    od.Discount = Convert.ToDecimal(element[4]);
                }

                foreach (var product in products)
                {
                    int orderDetailID = Convert.ToInt16(element[1]);
                    if (product.id == orderDetailID)
                    {
                        od.product = product;
                    }
                }

                orderDetails.Add(od);
            }

            var oqry = from line in orderLines.Skip(1)
                let elements = line.Split(';')
                select
                    new String[]
                    {
                        elements[0], elements[3], elements[4], elements[5], elements[7], elements[8], elements[9],
                        elements[10], elements[11], elements[12], elements[13]
                    };

            var listOfOrders = oqry.ToList();
            foreach (var element in listOfOrders)
            {
                Order o = new Order(
                    null,
                    Convert.ToDateTime(element[1]),
                    Convert.ToDateTime(element[2]),
                    Convert.ToDateTime(DateTime.MinValue),
                    Convert.ToDecimal(element[4]),
                    element[5],
                    element[6],
                    element[7],
                    element[8],
                    element[9],
                    element[10]
                    );

                if (String.IsNullOrEmpty(element[3]))
                {
                    //do nothing, standard DateTime is already minvalue
                }
                else
                {
                    o.shippedDate = Convert.ToDateTime(element[3]);
                }

                o.orderDetails = new List<Order_Details>();
                foreach (var orderDetail in orderDetails)
                {
                    int orderID = Convert.ToInt16(element[0]);
                    if (orderDetail.id == orderID)
                    {
                        o.orderDetails.Add(orderDetail);
                    }
                }

                orders.Add(o);
            }

            return orders;
        }

        public void CreateOrder(Order order)
        {
        }
    }
}