using System;
using System.Linq;
using Northwind;

namespace NorthwindApplication.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string EmployeeID{ get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public decimal TotalPrice { get; set; }

        private NorthwindController storageController = new NorthwindController();

        public OrderViewModel GetOrder(int orderId)
        {

            var order = storageController._orders.First(e => e.OrderID == orderId);
                return new OrderViewModel
                {
                    OrderID = order.OrderID,
                    CustomerID = order.Customer.ContactName,
                    EmployeeID = order.Employee.FirstName + " " + order.Employee.LastName,
                    OrderDate = order.OrderDate,
                    ShippedDate = order.ShippedDate,
                    ShipName = order.ShipName,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipRegion = order.ShipRegion,
                    ShipPostalCode = order.ShipPostalCode,
                    ShipCountry = order.ShipCountry,
                    TotalPrice = order.Order_Details.Sum(e => (e.UnitPrice * e.Quantity))
                };
        }

        public OrderViewModel GetOrder(Order order)
        {
            return new OrderViewModel
            {
                OrderID = order.OrderID,
                CustomerID = order.Customer.ContactName,
                EmployeeID = order.Employee.FirstName + " " + order.Employee.LastName,
                OrderDate = order.OrderDate,
                ShippedDate = order.ShippedDate,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry,
                TotalPrice = order.Order_Details.Sum(e => e.UnitPrice * e.Quantity)
            };
        }
    }
}