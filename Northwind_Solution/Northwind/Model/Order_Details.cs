using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Order_Details
    {
        public int _id { get; private set; }
        private Product _product { get; set; }
        private decimal _unitPrice { get; set; }
        private int _quantity { get; set; }
        private decimal _discount { get; set; }

        public Order_Details(int id, Product product, decimal unitPrice, int quantity, decimal discount)
        {
            _id = id;
            _product = product;
            _unitPrice = unitPrice;
            _quantity = quantity;
            _discount = discount;
        }

        public override string ToString()
        {
            return "Order details\n      ID: " + _id +
                "\n      Product: " + _product +
                "\n      Unit Price: " + _unitPrice +
                "\n      Quantity: " + _quantity +
                "\n      Discount: " + _discount;
        }
    }
}
