using System;
using System.Collections.Generic;
using System.Linq;
using Northwind;
using Northwind.DataStorage;

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

        public IList<OrderDetailViewModel> OrderDetailViews { get; set; }

        private OrderDetailViewModel orderdetailsObject = new OrderDetailViewModel();


        private NorthwindController storageController;

        public OrderViewModel(IDataStorage iStorage)
        {
            storageController = new NorthwindController(iStorage);
        }
        public OrderViewModel() : this(new DataStorageDB())
        {
            
        }

        public OrderViewModel GetOrder(int orderId)
        {

            var order = storageController._orders.First(e => e.OrderID == orderId);
                return new OrderViewModel
                {
                    OrderID = order.OrderID,
                    CustomerID = order.Customer.ContactName,
                    EmployeeID = order.Employee.FirstName + " " + order.Employee.LastName,
                    OrderDate = order.OrderDate.Value,
                    ShippedDate = order.ShippedDate,
                    ShipName = order.ShipName,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipRegion = order.ShipRegion,
                    ShipPostalCode = order.ShipPostalCode,
                    ShipCountry = order.ShipCountry,
                    TotalPrice = order.Order_Details.Sum(e => (e.UnitPrice * e.Quantity) - (e.UnitPrice * e.Quantity * (decimal)e.Discount)),
                    OrderDetailViews = orderdetailsObject.GetOrderDetails(orderId)
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
                TotalPrice = order.Order_Details.Sum(e => (e.UnitPrice * e.Quantity) - (e.UnitPrice * e.Quantity * (decimal)e.Discount)),
                OrderDetailViews = orderdetailsObject.GetOrderDetails(order.Order_Details.ToList())
            };
        }
    }
}