using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Model
{
    class Product
    {
        public int _id { get; private set; }
        public string _name { get; private set; }
        private Category _category { get; set; }
        private string _quantityPerUnit { get; set; }
        private decimal _unitPrice { get; set; }
        private int _unitsInStock { get; set; }
        private int _unitsOnOrder { get; set; }
        private int _reorderLevel { get; set; }
        private bool _discontinued { get; set; }

        public Product(int id, string name, Category category, string quantityPerUnit, decimal unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            _id = id;
            _name = name;
            _category = category;
            _quantityPerUnit = quantityPerUnit;
            _unitPrice = unitPrice;
            _unitsInStock = unitsInStock;
            _unitsOnOrder = unitsOnOrder;
            _reorderLevel = reorderLevel;
            _discontinued = discontinued;
        }


        public override string ToString()
        {
            return  "Product" + "\n   ID: " + _id + 
                    "\n   Name: " + _name + 
                    "\n   " + _category +
                    "\n   QuantityPerUnit: " + _quantityPerUnit +
                    "\n   UnitPrice: " + _unitPrice +
                    "\n   UnitsInStock: " + _unitsInStock +
                    "\n   UnitsOnOrder: " + _unitsOnOrder +
                    "\n   ReorderLevel: " + _reorderLevel +
                    "\n   Discontinued: " + _discontinued;
        }
    }
}
