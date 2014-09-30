using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Order
    {
        private Order_Details _OrderDetails;
        private DateTime _OrderDate;
        private DateTime _RequiredDate;
        private DateTime _ShippedDate;
        private decimal _Freight;
        private string _ShipName;
        private string _ShipAddress;
        private string _ShipCity;
        private string _ShipRegion;
        private string _ShipPostalCode;
        private string _ShipCountry;

        public Order(Order_Details orderDetails, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            _OrderDetails = orderDetails;
            _OrderDate = orderDate;
            _RequiredDate = requiredDate;
            _ShippedDate = shippedDate;
            _Freight = freight;
            _ShipName = shipName;
            _ShipAddress = shipAddress;
            _ShipCity = shipCity;
            _ShipRegion = shipRegion;
            _ShipPostalCode = shipPostalCode;
            _ShipCountry = shipCountry;
        }
    }
}
