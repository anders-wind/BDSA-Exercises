using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind;
using Northwind.DataStorage;

namespace NorthwindApplication.ViewModels
{
    public class OrderDetailViewModel : ViewModelBase
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }

        private NorthwindController storageController;

        public OrderDetailViewModel(IDataStorage iStorage)
        {
            storageController = new NorthwindController(iStorage);
        }
        public OrderDetailViewModel()
            : this(new DataStorageDB())
        {
            
        }


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

        protected bool Equals(OrderDetailViewModel other)
        {
            return string.Equals(ProductName, other.ProductName) && UnitPrice == other.UnitPrice && Quantity == other.Quantity && Discount.Equals(other.Discount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OrderDetailViewModel) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (ProductName != null ? ProductName.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ UnitPrice.GetHashCode();
                hashCode = (hashCode*397) ^ Quantity;
                hashCode = (hashCode*397) ^ Discount.GetHashCode();
                return hashCode;
            }
        }
    }
}
