using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Reporting_Module
{
    class ProductsBySaleDto
    {
        public ProductsBySaleDto(int productId, string productName, IList<UnitsSoldByMonth> unitsSoldByMonth)
        {
            ProductId = productId;
            ProductName = productName;
            UnitsSoldByMonth = unitsSoldByMonth;
        }

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public IList<UnitsSoldByMonth> UnitsSoldByMonth { get; private set; }
        //UnitsSoldByMonth [list of UnitsSold : int, Count : int, Month : int, Year : int]
    }
}
