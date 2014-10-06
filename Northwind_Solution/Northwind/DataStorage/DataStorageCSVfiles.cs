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
            IList<Category> categories = new List<Category>();
            string[] productLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/products.csv");
            string[] categoryLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/categories.csv");

            var pqry = from line in productLines.Skip(1)
                      let elements = line.Split(';')
                      select new String[]{ elements[0], elements[1], elements[3], elements[4], elements[5], elements[6], elements[7], elements[8], elements[9] };

            var cqry = from line in categoryLines.Skip(1)
                       let elements = line.Split(';')
                       select new String[] { elements[0], elements[1], elements[2] };

            var listOfCategories = cqry.ToList();
            foreach(var element in listOfCategories)
            {
                Category c = new Category(
                    Convert.ToInt16(element[0]),
                    element[1],
                    element[2],
                    ""
                    );

                categories.Add(c);
            }

            var listOfProducts = pqry.ToList();
            foreach (var element in listOfProducts)
            {
                Product p = new Product(
                    Convert.ToInt16(element[0]),
                    element[1],
                    null,
                    element[3],
                    Convert.ToDecimal(element[4]),
                    Convert.ToInt16(element[5]),
                    Convert.ToInt16(element[6]),
                    Convert.ToInt16(element[7]),
                    false
                    );

                foreach(var category in categories)
                {
                    int productID = Convert.ToInt16(element[2]);
                    if(category.id == productID)
                    {
                        p.category = category;
                    }
                }

                if(Convert.ToInt16(element[8]) == -1)
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

        public IList<Category> Categories()
        {
            IList<Category> categories = new List<Category>();

            string[] categoryLines = System.IO.File.ReadAllLines(@"../../../northwind_csv_data/categories.csv");

            var cqry = from line in categoryLines.Skip(1)
                       let elements = line.Split(';')
                       select new String[] { elements[0], elements[1], elements[2] };

            var listOfCategories = cqry.ToList();
            foreach (var element in listOfCategories)
            {
                Category c = new Category(
                    Convert.ToInt16(element[0]),
                    element[1],
                    element[2],
                    ""
                    );

                categories.Add(c);
            }

            return categories;
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
                        select new String[] { elements[0], elements[1], elements[2], elements[3], elements[4] };

            var listOfOrderDetails = odqry.ToList();
            foreach(var element in listOfOrderDetails)
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

                    List<Product> orderedProducts = new List<Product>();
                    foreach (var product in products)
                    {
                        int orderDetailID = Convert.ToInt16(element[1]);
                        if (product.id == orderDetailID)
                        {
                            orderedProducts.Add(product);
                        }
                    }
                    od.products = orderedProducts;

                    orderDetails.Add(od);
            }

            var oqry = from line in orderLines.Skip(1)
                       let elements = line.Split(';')
                       select new String[] { elements[0], elements[3], elements[4], elements[5], elements[7], elements[8], elements[9], elements[10], elements[11], elements[12], elements[13] };

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

                if(String.IsNullOrEmpty(element[3]))
                {
                    //do nothing, standard DateTime is already minvalue
                } else
                {
                    o.shippedDate = Convert.ToDateTime(element[3]);
                }

                foreach (var orderDetail in orderDetails)
                {
                    int orderID = Convert.ToInt16(element[0]);
                    if(orderDetail.id == orderID)
                    {
                        o.orderDetails = orderDetail;
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
