using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind;

namespace NorthwindApplication.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private OrderViewModel order = new OrderViewModel();
        private NorthwindController storageController = new NorthwindController();

        public ObservableCollection<OrderViewModel> ordersList { get; set; }

        public OrdersViewModel()
        {
            ordersList = new ObservableCollection<OrderViewModel>();
        }
        public IList<OrderViewModel> GetOrders()
        {
            var listOfOrders = storageController._orders;

            foreach (var orderId in listOfOrders)
            {
                ordersList.Add(order.GetOrder(orderId));
            }

            return ordersList;
        }
    }
}
