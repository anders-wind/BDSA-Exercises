using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class OrderCSV
    {
        public static int _maxID { get; private set; }
        private int _id { get; set; }
        private IList<Order_DetailsCSV> _orderDetails { get; set; }
        private DateTime _orderDate { get; set; }
        private DateTime _requiredDate { get; set; }
        public DateTime? _shippedDate { get; private set; }
        private decimal _freight { get; set; }
        private string _shipName { get; set; }
        private string _shipAddress { get; set; }
        private string _shipCity { get; set; }
        private string _shipRegion { get; set; }
        private string _shipPostalCode { get; set; }
        public string _shipCountry { get; private set; }

        public OrderCSV(int ID, IList<Order_DetailsCSV> orderDetails, DateTime orderDate, DateTime requiredDate, DateTime? shippedDate, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            if (ID > _maxID) _maxID = ID;
            _orderDetails = orderDetails;
            _orderDate = orderDate;
            _requiredDate = requiredDate;
            _shippedDate = shippedDate;
            _freight = freight;
            _shipName = shipName;
            _shipAddress = shipAddress;
            _shipCity = shipCity;
            _shipRegion = shipRegion;
            _shipPostalCode = shipPostalCode;
            _shipCountry = shipCountry;
        }

        public override string ToString()
        {
            return "Order\n      Order Details: " + _orderDetails +
                "\n      Order Date: " + _orderDate +
                "\n      Required Date: " + _requiredDate +
                "\n      Shipped Date: " + _shippedDate +
                "\n      Freight: " + _freight +
                "\n      Ship Name: " + _shipName +
                "\n      Ship Adress: " + _shipAddress +
                "\n      Ship City: " + _shipCity +
                "\n      Ship Region: " + _shipRegion +
                "\n      Ship Postal Code: " + _shipPostalCode +
                "\n      Ship Country: " + _shipCountry;
        }
    }
}
