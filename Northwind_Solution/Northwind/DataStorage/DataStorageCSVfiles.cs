using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataStorage
{
    internal class DataStorageCSVfiles : IDataStorage
    {
        private string productCSVFilePath = @"../../../northwind_csv_data/products.csv";
        private string categoriesCSVFilePath = @"../../../northwind_csv_data/categories.csv";
        private string orderCSVFilePath = @"../../../northwind_csv_data/orders.csv";
        private string orderDetailsCSVFilePath = @"../../../northwind_csv_data/order_details.csv";

        public IList<Order> _orders { get; private set; }
        public IList<Product> _products { get; private set; }

        public DataStorageCSVfiles()
        {
            _orders = Orders();
            _products = Products();
        }
        public IList<Product> Products()
        {
            if (_products != null) return _products;
            string[] productLines = System.IO.File.ReadAllLines(productCSVFilePath);
            string[] categoryLines = System.IO.File.ReadAllLines(categoriesCSVFilePath);

            var categoryQuery = from line in categoryLines.Skip(1)
                                let elements = line.Split(';')
                                select new Category(Int32.Parse(elements[0]), elements[1], elements[2]);

            var listOfCategories = categoryQuery.ToList();

            var productQuery = from line in productLines.Skip(1)
                               let elements = line.Split(';')
                               let id = Int32.Parse(elements[0])
                               let name = elements[1]
                               let category = findCategory(listOfCategories, Int32.Parse(elements[3]))
                               let quantityPerUnit = elements[4]
                               let unitPrice = decimal.Parse(elements[5])
                               let unitsInStock = Int16.Parse(elements[6])
                               let unitsOnOrder = Int16.Parse(elements[7])
                               let reorderLevel = Int16.Parse(elements[8])
                               let discontinued = isDiscontinued(Int32.Parse(elements[9]))
                               select
                                   new Product(id, name, Int32.Parse(elements[3]), quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel,
                                       discontinued, category);

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
                if (category.CategoryID == ID)
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
                if (product.ProductID == ID)
                {
                    return product;
                }
            }
            return null;
        }

        private IList<Order_Detail> findOrderDetails(IList<Order_Detail> orderDetails, int ID)
        {
            var tempList = new List<Order_Detail>();
            foreach (var orderDetail in orderDetails)
            {
                if (orderDetail.ProductID == ID)
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
                                select new Category(Int32.Parse(elements[0]), elements[1], elements[2]);

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
                               let unitsInStock = Int16.Parse(elements[6])
                               let unitsOnOrder = Int16.Parse(elements[7])
                               let reorderLevel = Int16.Parse(elements[8])
                               let discontinued = isDiscontinued(Int32.Parse(elements[9]))
                               select
                                   new Product(id, name, ID, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel,
                                       discontinued, category);

            //Console.WriteLine("Products with category ID: " + ID);
            //foreach (var product in productQuery)
            //{
            //    Console.WriteLine(product);
            //}

            return productQuery.ToList();
        }

        public IList<Order> Orders()
        {
            if (_orders != null) return _orders;
            IList<Product> products = Products();

            string[] orderLines = System.IO.File.ReadAllLines(orderCSVFilePath);
            string[] orderDetailLines = System.IO.File.ReadAllLines(orderDetailsCSVFilePath);

            var orderDetailsQuery = from line in orderDetailLines.Skip(1)
                                    let elements = line.Split(';')
                                    let id = Int32.Parse(elements[0])
                                    let product = findProduct(products, Int32.Parse(elements[1]))
                                    let unitPrice = decimal.Parse(elements[2])
                                    let quantity = Int16.Parse(elements[3])
                                    let discount = float.Parse(elements[4], System.Globalization.NumberStyles.Any)
                                    select new Order_Detail(id, Int32.Parse(elements[1]), unitPrice, quantity, discount, product);

            var listOfOrderDetails = orderDetailsQuery.ToList();

            var orderQuery = from line in orderLines.Skip(1)
                             let elements = line.Split(';')
                             let ID = Int32.Parse(elements[0])
                             let orderDetailElement = findOrderDetails(listOfOrderDetails, Int32.Parse(elements[0]))
                             let orderDate = DateTime.Parse(elements[3])
                             let requiredDate = DateTime.Parse(elements[4])
                             let shippedDate = fixEmptyTime(elements[5])
                             let freight = decimal.Parse(elements[7])
                             let shipname = elements[8]
                             let shipAddress = elements[9]
                             let shipCity = elements[10]
                             let shipRegion = elements[11]
                             let shipPostalCode = elements[12]
                             let shipCountry = elements[13]
                             select new Order(ID, orderDate, requiredDate, shippedDate, freight, shipname, shipAddress, shipCity, shipRegion, shipPostalCode, orderDetailElement, shipCountry);

            //Order(int orderId, DateTime? orderDate, DateTime? requiredDate, DateTime? shippedDate, decimal? freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, ICollection<Order_Detail> orderDetails, string shipCountry)

            //Console.WriteLine("Orders");
            //foreach (var order in listOfOrders)
            //{
            //    Console.WriteLine(order);
            //}


            return orderQuery.ToList();
        }

        public IList<Employee> Employees()
        {
            throw new NotImplementedException();
        }

        public IList<Order_Detail> OrderDetails()
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(Order order)
        {
        }

        public int maxOrderID()
        {
            string[] orderLines = System.IO.File.ReadAllLines(orderCSVFilePath);
            var orderQuery = from line in orderLines.Skip(1)
                let elements = line.Split(';')
                select elements[0];
            return Int32.Parse(orderQuery.Max(e => e));
        }
    }
}