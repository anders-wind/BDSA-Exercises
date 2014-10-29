using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind;

namespace NorthwindApplication.ViewModels
{
    class OrdersViewModel : ViewModelBase
    {
        private OrderViewModel order = new OrderViewModel();
        private NorthwindController storageController = new NorthwindController();

        private IList<OrderViewModel> ordersList =  new List<OrderViewModel>();

        public IList<OrderViewModel> GetOrders()
        {
            var listOfOrders = storageController._orders.Select(e => e.OrderID);

            foreach (var orderId in listOfOrders)
            {
                ordersList.Add(order.GetOrder(orderId));
            }

            return ordersList;
        }
    }
}
