using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataStorage;
using Northwind.Model;

namespace Northwind
{
    class NorthwindController
    {
        public IList<Order> _orders
        {
            get { return _storage.Orders(); }
        }
        public IList<Product> _products
        {
            get { return _storage.Products(); }
        }

        public IDataStorage _storage { get; private set; }

        public event Action<object, Order> NewOrderEvent;

        public NorthwindController(IDataStorage storage)
        {
            _storage = storage;
        }

        public void AddOrder(IList<Order_Detail> orderDetails, DateTime requiredDate, DateTime? shippedDate, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            Order tempOrder = new Order(_storage.maxOrderID() + 1,DateTime.Now,requiredDate,shippedDate,freight,shipName,shipAddress,shipCity,shipRegion,shipPostalCode,orderDetails,shipCountry);
            
            _storage.CreateOrder(tempOrder);

            if (NewOrderEvent != null)
            {
                NewOrderEvent.Invoke(this, tempOrder);
            }
        }

        public void Subscribe(Action<object, Order> action)
        {
            NewOrderEvent += action;
        }

    }
}
