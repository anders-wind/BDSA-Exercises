using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind;

namespace NorthwindApplication.ViewModels
{
    public class OrderDetailViewModel : ViewModelBase
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        private NorthwindController storageController = new NorthwindController();


        public IList<OrderDetailViewModel> GetOrderDetails(int orderId)
        {

            var orderDetail = storageController._orderDetails.Select(e => e).Where(x => x.OrderID == orderId);
            var tempList = new List<OrderDetailViewModel>(); 

            foreach (var od in orderDetail)
            {
                tempList.Add(new OrderDetailViewModel
                {
                    ProductName = od.Product.ProductName,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                });
            }

            return tempList;
        }

        public IList<OrderDetailViewModel> GetOrderDetails(IList<Order_Detail> orderDetailsFromOrder)
        {
            var tempList = new List<OrderDetailViewModel>(); 
            foreach (var od in orderDetailsFromOrder)
            {
                tempList.Add(new OrderDetailViewModel
                {
                    ProductName = od.Product.ProductName,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                });
            }

            return tempList;
        }
    }
}
