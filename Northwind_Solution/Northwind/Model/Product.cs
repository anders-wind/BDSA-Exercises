using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Product
    {        
        private string _name;
        //private Category _category;
        private string _QuantityPerUnit;
        private decimal _UnitPrice;
        private int _UnitsInStock;
        private int _UnitsOnOrder;
        private int _ReorderLevel;
        //private bool _Discontinued;

        public Product(string name, /*Category category*/ string quantityPerUnit, decimal unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel /*bool discontinued*/)
        {
            _name = name;
            //_category = category;
            _QuantityPerUnit = quantityPerUnit;
            _UnitPrice = unitPrice;
            _UnitsInStock = unitsInStock;
            _UnitsOnOrder = unitsOnOrder;
            _ReorderLevel = reorderLevel;
            //_Discontinued = discontinued;
        }

        public Product()
        {
            // TODO: Complete member initialization
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

        public string unitPrice
        {
            get
            {
                return _UnitPrice.ToString();
            }
            set
            {
                try
                {
                    _UnitPrice = decimal.Parse(value);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public string unitsInStock
        {
            get
            {
                return _UnitsInStock.ToString();
            }
            set
            {
                try
                {
                    _UnitsInStock = int.Parse(value);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public string unitsOnOrder
        {
            get
            {
                return _UnitsOnOrder.ToString();
            }
            set
            {
                try
                {
                    _UnitsOnOrder = int.Parse(value);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public string reorderLevel
        {
            get
            {
                return _ReorderLevel.ToString();
            }
            set
            {
                try
                {
                    _ReorderLevel = int.Parse(value);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
