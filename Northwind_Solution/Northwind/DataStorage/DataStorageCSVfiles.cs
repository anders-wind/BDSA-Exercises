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
        private string productCSVFilePath = @"../../../northwind_csv_data/products.csv";
        private string categoriesCSVFilePath = @"../../../northwind_csv_data/categories.csv";
        private string orderCSVFilePath = @"../../../northwind_csv_data/orders.csv";
        private string orderDetailsCSVFilePath = @"../../../northwind_csv_data/order_details.csv";

        public IList<Product> Products()
        {
            IList<Category> categories = new List<Category>();
            string[] productLines = System.IO.File.ReadAllLines(productCSVFilePath);
            string[] categoryLines = System.IO.File.ReadAllLines(categoriesCSVFilePath);

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
                if (category._id == ID)
                {
                    return category;
                }
            }
            return null;
        }

        private Product findProduct(IList<Product> products, int ID)
        {
            foreach (var product in products)
            {
                if (product._id == ID)
                {
                    return product;
                }
            }
            return null;
        }

        private IList<Order_Details> findOrderDetails(IList<Order_Details> orderDetails, int ID)
        {
            var tempList = new List<Order_Details>();
            foreach (var orderDetail in orderDetails)
            {
                if (orderDetail._id == ID)
                {
                     tempList.Add(orderDetail);
                }
            }
            return tempList;
        }

        private DateTime? fixEmptyTime(string Date)
        {
            if (String.IsNullOrEmpty(Date))
            {
                return null;
            }
            else
            {
                return DateTime.Parse(Date);
            }
        }

        public IList<Product> Categories(int ID)
        {
            string[] categoryLines = System.IO.File.ReadAllLines(categoriesCSVFilePath);
            var categoryQuery = from line in categoryLines.Skip(1)
                                let elements = line.Split(';')
                                where Int32.Parse(elements[0]) == ID
                                select new Category(Int32.Parse(elements[0]), elements[1], elements[2], "");

            var listOfCategories = categoryQuery.ToList();

            string[] productLines = System.IO.File.ReadAllLines(productCSVFilePath);
            var productQuery = from line in productLines.Skip(1)
                               let elements = line.Split(';')
                               where Int32.Parse(elements[3]) == ID
                               let id = Int32.Parse(elements[0])
                               let name = elements[1]
                               let category = listOfCategories[0]
                               let quantityPerUnit = elements[4]
                               let unitPrice = decimal.Parse(elements[5])
                               let unitsInStock = Int32.Parse(elements[6])
                               let unitsOnOrder = Int32.Parse(elements[7])
                               let reorderLevel = Int32.Parse(elements[8])
                               let discontinued = isDiscontinued(Int32.Parse(elements[9]))
                               select
                                   new Product(id, name, category, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel,
                                       discontinued);

            //Console.WriteLine("Products with category ID: " + ID);
            //foreach (var product in productQuery)
            //{
            //    Console.WriteLine(product);
            //}

            return productQuery.ToList();
        }

        public IList<Order> Orders()
        {
            IList<Product> products = Products();

            IList<Order> orders = new List<Order>();
            IList<Order_Details> orderDetails = new List<Order_Details>();
            string[] orderLines = System.IO.File.ReadAllLines(orderCSVFilePath);
            string[] orderDetailLines = System.IO.File.ReadAllLines(orderDetailsCSVFilePath);

            var orderDetailsQuery = from line in orderDetailLines.Skip(1)
                let elements = line.Split(';')
                let id = Int32.Parse(elements[0])
                let product = findProduct(products, Int32.Parse(elements[1]))
                let unitPrice = decimal.Parse(elements[2])
                let quantity = Int32.Parse(elements[3])
                let discount = decimal.Parse(elements[4], System.Globalization.NumberStyles.Any)
                select new Order_Details(id, product,unitPrice,quantity,discount);

            var listOfOrderDetails = orderDetailsQuery.ToList();


            var orderQuery = from line in orderLines.Skip(1)
                let elements = line.Split(';')
                let orderDetailElement = findOrderDetails(listOfOrderDetails, Int32.Parse(elements[0]))
                let orderDate = DateTime.Parse(elements[3])
                let requiredDate = DateTime.Parse(elements[4])
                let shippedDate = fixEmptyTime(elements[5]) // DateTime.Parse(elements[5]) // maybe this is empty.
                let freight = decimal.Parse(elements[7])
                let shipname = elements[8]
                let shipAddress = elements[9]
                let shipCity = elements[10]
                let shipRegion = elements[11]
                let shipPostalCode = elements[12]
                let shipCountry = elements[13]
                select new Order(orderDetailElement, orderDate, requiredDate, shippedDate, freight, shipname, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry);

            var listOfOrders = orderQuery.ToList();


            //Console.WriteLine("Orders");
            //foreach (var order in listOfOrders)
            //{
            //    Console.WriteLine(order);
            //}

            
            return orders;
        }

        public void CreateOrder(Order order)
        {
        }
    }
}