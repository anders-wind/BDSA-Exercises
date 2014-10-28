using System;
using System.Linq;
using Northwind;

namespace NorthwindApplication.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private int _orderID;
        public int OrderID
        {
            get { return _orderID; }
            set
            {
                if (_orderID == value)
                {
                    return;
                }
                _orderID = value;
                RaisePropertyChanged("OrderID");
            }
        }

        private string _costumerID;
        public string CustomerID
        {
            get { return _costumerID; }
            set
            {
                if (_costumerID == value)
                {
                    return;
                }
                _costumerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        private Nullable<int> _employeeId;

        public Nullable<int> EmployeeID
        {
            get { return _employeeId; }
            set
            {
                if (_employeeId == value)
                {
                    return;
                }
                _employeeId = value;
                RaisePropertyChanged("EmployeeID");
            }
        }

        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        private NorthwindController storageController = new NorthwindController();

        public OrderViewModel GetOrder(int orderId)
        {

            var order = storageController._orders.First(e => e.OrderID == orderId);
                return new OrderViewModel
                {
                    OrderID = order.OrderID,
                    CustomerID = order.CustomerID,
                    EmployeeID = order.EmployeeID,
                    OrderDate = order.OrderDate,
                    ShippedDate = order.ShippedDate,
                    ShipName = order.ShipName,
                    ShipAddress = order.ShipAddress,
                    ShipCity = order.ShipCity,
                    ShipRegion = order.ShipRegion,
                    ShipPostalCode = order.ShipPostalCode,
                    ShipCountry = order.ShipCountry
                };
        }
    }
}