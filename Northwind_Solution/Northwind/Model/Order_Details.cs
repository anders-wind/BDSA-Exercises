using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Order_Details
    {
        private Product _Product;
        private decimal _UnitPrice;
        private int _Quantity;
        private decimal _Discount;

        public Order_Details(Product product, decimal unitPrice, int quantity, decimal discount)
        {
            _Product = product;
            _UnitPrice = unitPrice;
            _Quantity = quantity;
            _Discount = discount;
        }
    }
}
