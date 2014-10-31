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
            OrderDate = null;
            ShippedDate = null;
        }
        public OrderViewModel() : this(new DataStorageDB())
        {
            
        }

        public OrderViewModel GetOrder(int orderId)
        {

            var order = storageController._orders.First(e => e.OrderID == orderId);
                return new OrderViewModel()
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

        protected bool Equals(OrderViewModel other)
        {
            return string.Equals(CustomerID, other.CustomerID) && OrderID == other.OrderID && string.Equals(EmployeeID, other.EmployeeID) && OrderDate.Equals(other.OrderDate) && string.Equals(ShipName, other.ShipName) && string.Equals(ShipAddress, other.ShipAddress) && string.Equals(ShipCity, other.ShipCity) && string.Equals(ShipRegion, other.ShipRegion) && string.Equals(ShipPostalCode, other.ShipPostalCode) && string.Equals(ShipCountry, other.ShipCountry) && TotalPrice == other.TotalPrice;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderViewModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (storageController != null ? storageController.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CustomerID != null ? CustomerID.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ OrderID;
                hashCode = (hashCode*397) ^ (orderdetailsObject != null ? orderdetailsObject.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (EmployeeID != null ? EmployeeID.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ OrderDate.GetHashCode();
                hashCode = (hashCode*397) ^ ShippedDate.GetHashCode();
                hashCode = (hashCode*397) ^ (ShipName != null ? ShipName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ShipAddress != null ? ShipAddress.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ShipCity != null ? ShipCity.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ShipRegion != null ? ShipRegion.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ShipPostalCode != null ? ShipPostalCode.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (ShipCountry != null ? ShipCountry.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (OrderDetailViews != null ? OrderDetailViews.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ TotalPrice.GetHashCode();
                return hashCode;
            }
        }
    }
}