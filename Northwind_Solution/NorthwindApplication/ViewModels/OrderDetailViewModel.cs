using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind;

namespace NorthwindApplication.ViewModels
{
    class OrderDetailViewModel : ViewModelBase
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        private NorthwindController storageController = new NorthwindController();

        private IList<OrderDetailViewModel> orderDetails = new List<OrderDetailViewModel>(); 

        public IList<OrderDetailViewModel> GetOrderDetails(int orderId)
        {

            var orderDetail = storageController._orderDetails.Select(e => e).Where(x => x.OrderID == orderId);

            foreach (var od in orderDetail)
            {
                orderDetails.Add(new OrderDetailViewModel
                {
                    ProductName = od.Product.ProductName,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                });
            }

            return orderDetails;
        }
    }
}
