using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataStorage;
using Northwind.Model;

namespace Northwind
{
    class NorthwindController
    {
        public IList<Order> _orders { get; private set; }
        public IList<Product> _products { get; private set; }
        public IList<object> _subscribers { get; private set; }

        private IDataStorage _storage;

        public NorthwindController(IDataStorage storage)
        {
            _subscribers = new List<object>();
            _storage = storage;
            _orders = _storage.Orders();
            _products = _storage.Products();
        }

        public void AddOrder(IList<Order_Details> orderDetails, DateTime requiredDate, DateTime? shippedDate, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            Order tempOrder = new Order(Order._maxID + 1, orderDetails,DateTime.Now, requiredDate,shippedDate,freight,shipName,shipAddress,shipCity,shipRegion,shipPostalCode,shipCountry);
            
            _orders.Add(tempOrder);
            
            _storage.CreateOrder(tempOrder);

            NewOrderEvent();
        }

        public void NewOrderEvent()
        {
            foreach (var subscriber in _subscribers)
            {
                Console.WriteLine("notify dat subscriber");// do something
            }
        }
    }
}
