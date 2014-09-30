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
    }
}
