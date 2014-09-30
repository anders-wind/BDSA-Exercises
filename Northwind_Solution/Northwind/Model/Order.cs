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
    }
}
