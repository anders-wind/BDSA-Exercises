using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind;
using Northwind.DataStorage;

namespace NorthwindApplication.ViewModels
{
    public class OrdersViewModel : ViewModelBase
    {
        private OrderViewModel order = new OrderViewModel();
        private NorthwindController storageController;

        public ObservableCollection<OrderViewModel> ordersList { get; set; }

        public OrdersViewModel(IDataStorage iStorage)
        {
            storageController = new NorthwindController(iStorage);
            ordersList = new ObservableCollection<OrderViewModel>();
        }
        public OrdersViewModel()
            : this(new DataStorageDB())
        {
            
        }
        public IList<OrderViewModel> GetOrders()
        {
            var listOfOrders = storageController._orders;

            foreach (var orderObject in listOfOrders)
            {
                ordersList.Add(order.GetOrder(orderObject));
            }

            return ordersList;
        }
    }
}
