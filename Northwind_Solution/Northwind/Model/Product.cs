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
        private Category _category;
        private string _QuantityPerUnit;
        private decimal _UnitPrice;
        private int _UnitsInStock;
        private int _UnitsOnOrder;
        private int _ReorderLevel;
        private bool _Discontinued;

        public Product(string name, Category category, string quantityPerUnit, decimal unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, bool discontinued)
        {
            _name = name;
            _category = category;
            _QuantityPerUnit = quantityPerUnit;
            _UnitPrice = unitPrice;
            _UnitsInStock = unitsInStock;
            _UnitsOnOrder = unitsOnOrder;
            _ReorderLevel = reorderLevel;
            _Discontinued = discontinued;
        }
    }
}
