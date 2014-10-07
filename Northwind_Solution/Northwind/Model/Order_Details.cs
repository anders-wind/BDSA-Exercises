using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Order_Details
    {
        private int _id;
        private Product _Product;
        private decimal _UnitPrice;
        private int _Quantity;
        private decimal _Discount;

        public Order_Details(int id, Product product, decimal unitPrice, int quantity, decimal discount)
        {
            _id = id;
            _Product = product;
            _UnitPrice = unitPrice;
            _Quantity = quantity;
            _Discount = discount;
        }

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public Product product
        {
            get
            {
                return _Product;
            }
            set
            {
                _Product = value;
            }
        }

        public decimal unitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                _UnitPrice = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
            }
        }

        public decimal Discount
        {
            get
            {
                return _Discount;
            }
            set
            {
                _Discount = value;
            }
        }
    }
}
