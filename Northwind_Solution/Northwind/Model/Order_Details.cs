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
        private List<Product> _Products;
        private decimal _UnitPrice;
        private int _Quantity;
        private decimal _Discount;

        public Order_Details(int id, List<Product> products, decimal unitPrice, int quantity, decimal discount)
        {
            _id = id;
            _Products = products;
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

        public List<Product> products
        {
            get
            {
                return _Products;
            }
            set
            {
                _Products = value;
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
