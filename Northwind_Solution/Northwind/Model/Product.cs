using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Product
    {
        private int _id;
        private string _name;
        private Category _category;
        private string _QuantityPerUnit;
        private decimal _UnitPrice;
        private int _UnitsInStock;
        private int _UnitsOnOrder;
        private int _ReorderLevel;
        private bool _Discontinued;

        public Product(int id, string name, Category category, string quantityPerUnit, decimal unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            _id = id;
            _name = name;
            _category = category;
            _QuantityPerUnit = quantityPerUnit;
            _UnitPrice = unitPrice;
            _UnitsInStock = unitsInStock;
            _UnitsOnOrder = unitsOnOrder;
            _ReorderLevel = reorderLevel;
            _Discontinued = discontinued;
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

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Category category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
            }
        }

        public string quantityPerUnit
        {
            get
            {
                return _QuantityPerUnit;
            }
            set
            {
                _QuantityPerUnit = value;
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

        public int unitsInStock
        {
            get
            {
                return _UnitsInStock;
            }
            set
            {

                _UnitsInStock = value;
            }
        }

        public int unitsOnOrder
        {
            get
            {
                return _UnitsOnOrder;
            }
            set
            {
                _UnitsOnOrder = value;
            }
        }

        public int reorderLevel
        {
            get
            {
                return _ReorderLevel;
            }
            set
            {
                _ReorderLevel = value;       
            }
        }

        public bool discontinued
        {
            get
            {
                return _Discontinued;
            }
            set
            {
                _Discontinued = value;
            }
        }
    }
}
