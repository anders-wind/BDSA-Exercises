
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataStorage
{
    public class DataStorageMock : IDataStorage
    {
        private IList<Product> _products = new List<Product>();
        private IList<Order> _orders = new List<Order>();
        private IList<Category> _categories = new List<Category>();
        private IList<Employee> _employees = new List<Employee>();
        private IList<Order_Detail> _orderDetails0 = new List<Order_Detail>();
        private IList<Order_Detail> _orderDetails1 = new List<Order_Detail>();
        private IList<Order_Detail> _orderDetails2 = new List<Order_Detail>();
        private IList<Order_Detail> _orderDetails3 = new List<Order_Detail>();
        private IList<Customer> _customers = new List<Customer>(); 


        public DataStorageMock()
        {
            initiateCategories();
            initiateProducts();
            initiateOrderDetails();
            initiateEmployees();
            initiateCustomers();;
            initiateOrders();
        }

        private void initiateCategories()
        {
            _categories.Add(new Category()
            {
                CategoryID = 0,
                CategoryName = "Category 0",
                Description = "Category 0 description",
                Picture = new byte[0],
            });
           _categories.Add(new Category()
           {
               CategoryID = 1,
               CategoryName = "Category 1",
               Description = "Category 1 description",
               Picture = new byte[1],
           });
           _categories.Add(new Category()
           {
               CategoryID = 2,
               CategoryName = "Category 2",
               Description = "Category 2 description",
               Picture = new byte[2],
           });
           _categories.Add(new Category()
           {
               CategoryID = 3,
               CategoryName = "Category 3",
               Description = "Category 3 description",
               Picture = new byte[3],
           });
           

        }
        private void initiateProducts()
        {
            _products.Add(new Product()
            {
                Category = _categories[0],
                CategoryID = 0,
                Discontinued = true,
                ProductID = 0,
                ProductName = "product 0",
                QuantityPerUnit = "quantityPrUnit 0",
                ReorderLevel = 0,
                UnitPrice = 0,
            });
            _products.Add(new Product()
            {
                Category = _categories[1],
                CategoryID = 1,
                Discontinued = true,
                ProductID = 1,
                ProductName = "product 1",
                QuantityPerUnit = "quantityPrUnit 1",
                ReorderLevel = 1,
                UnitPrice = 1
            });
            _products.Add(new Product()
            {
                Category = _categories[2],
                CategoryID = 2,
                Discontinued = false,
                ProductID = 2,
                ProductName = "product 2",
                QuantityPerUnit = "quantityPrUnit 2",
                ReorderLevel = 2,
                UnitPrice = 2
            });
            _products.Add(new Product()
            {
                Category = _categories[3],
                CategoryID = 3,
                Discontinued = true,
                ProductID = 3,
                ProductName = "product 3",
                QuantityPerUnit = "quantityPrUnit 3",
                ReorderLevel = 3,
                UnitPrice = 3
            });

        }
        private void initiateOrderDetails()
        {
            _orderDetails0.Add(new Order_Detail()
            {
                Discount = 0,
                ProductID = 0,
                Product = _products[0],
                Quantity = 0,
                UnitPrice = 0,
            });
            _orderDetails0.Add(new Order_Detail()
            {
                Discount = 0,
                ProductID = 0,
                Product = _products[0],
                Quantity = 0,
                UnitPrice = 0,
            });
            //----------------------------
            _orderDetails1.Add(new Order_Detail()
            {
                Discount = 0.1f,
                ProductID = 1,
                Product = _products[1],
                Quantity = 1,
                UnitPrice = 1,
            });
            _orderDetails1.Add(new Order_Detail()
            {
                Discount = 0.1f,
                ProductID = 1,
                Product = _products[1],
                Quantity = 1,
                UnitPrice = 1,
            });
            //--------------------------
            _orderDetails2.Add(new Order_Detail()
            {
                Discount = 0.2f,
                ProductID = 2,
                Product = _products[2],
                Quantity = 2,
                UnitPrice = 2,
            });
            //-----------------------
            _orderDetails3.Add(new Order_Detail()
            {
                Discount = 0.3f,
                ProductID = 3,
                Product = _products[3],
                Quantity = 3,
                UnitPrice = 3,
            });
        }
        private void initiateEmployees()
        {
            _employees.Add(new Employee()
            {
                FirstName = "firstname 0",
                LastName = "lastname 0",
                EmployeeID = 0,
                Address = "address 0"
            });
            _employees.Add(new Employee()
            {
                FirstName = "firstname 1",
                LastName = "lastname 1",
                EmployeeID = 1,
                Address = "address 1"
            });
            _employees.Add(new Employee()
            {
                FirstName = "firstname 2",
                LastName = "lastname 2",
                EmployeeID = 2,
                Address = "address 2"
            });
            _employees.Add(new Employee()
            {
                FirstName = "firstname 3",
                LastName = "lastname 3",
                EmployeeID = 3,
                Address = "address 3"
            });
        }
        private void initiateCustomers()
        {
            _customers.Add(new Customer()
            {
                CustomerID = "Id 0",
                ContactName = "Customer 0",
                ContactTitle = "Customer title 0"
            });
            _customers.Add(new Customer()
            {
                CustomerID = "Id 1",
                ContactName = "Customer 1",
                ContactTitle = "Customer title 1"
            });
            _customers.Add(new Customer()
            {
                CustomerID = "Id 2",
                ContactName = "Customer 2",
                ContactTitle = "Customer title 2"
            });
            _customers.Add(new Customer()
            {
                CustomerID = "Id 3",
                ContactName = "Customer 3",
                ContactTitle = "Customer title 3"
            });
        }
        private void initiateOrders()
        {
            _orders.Add(new Order()
            {
                OrderID = 0,
                OrderDate = new DateTime(0,0,0),
                CustomerID = _customers[0].CustomerID,
                Customer = _customers[0],
                EmployeeID = _employees[0].EmployeeID,
                Employee = _employees[0],
                Freight = 0,
                Order_Details = _orderDetails0,
            });
            _orders.Add(new Order()
            {
                OrderID = 1,
                OrderDate = new DateTime(1, 1, 1),
                CustomerID = _customers[1].CustomerID,
                Customer = _customers[1],
                EmployeeID = _employees[1].EmployeeID,
                Employee = _employees[1],
                Freight = 1,
                Order_Details = _orderDetails1,
            });
            _orders.Add(new Order()
            {
                OrderID = 2,
                OrderDate = new DateTime(2, 2, 2),
                CustomerID = _customers[2].CustomerID,
                Customer = _customers[2],
                EmployeeID = _employees[2].EmployeeID,
                Employee = _employees[2],
                Freight = 2,
                Order_Details = _orderDetails2,
            });
            _orders.Add(new Order()
            {
                OrderID = 3,
                OrderDate = new DateTime(3, 3, 3),
                CustomerID = _customers[3].CustomerID,
                Customer = _customers[3],
                EmployeeID = _employees[3].EmployeeID,
                Employee = _employees[3],
                Freight = 3,
                Order_Details = _orderDetails3,
            });
        }

        public IList<Product> Products()
        {
            return _products;
        }

        public IList<Product> Categories(int ID)
        {
            return _products.Where(e=>e.CategoryID==ID).ToList();
        }

        public IList<Order> Orders()
        {
            return _orders;
        }

        public IList<Employee> Employees()
        {
            return _employees;
        }

        public IList<Order_Detail> OrderDetails()
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public int maxOrderID()
        {
            return 3;
        }

        public Order getOrder(int ID)
        {
            return _orders[3];
        }
    }
}
