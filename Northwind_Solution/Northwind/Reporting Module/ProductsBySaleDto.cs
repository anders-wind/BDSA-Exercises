using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Reporting_Module
{
    class ProductsBySaleDto
    {
        public ProductsBySaleDto(int productId, string productName, IList<UnitsSoldByMonth> unitsSoldByMonths)
        {
            ProductId = productId;
            ProductName = productName;
            UnitsSoldByMonths = unitsSoldByMonths;
        }

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public IList<UnitsSoldByMonth> UnitsSoldByMonths { get; private set; }

        public override string ToString()
        {
            string unitsSoldString = "";
            foreach (var unitSold in UnitsSoldByMonths)
            {
                unitsSoldString += "\n" + unitSold.UnitsSold.Sum(x => x) + " | " + unitSold.Count + " | " +
                                   unitSold.UnitsSold.Average(x => x) + " | " + unitSold.Month + " | " + unitSold.Year;
            }
            return "Product ID: " + ProductId + " Name " + ProductName + "\n" +
                   "Quantity | Count | Avg | Month | Year" + "\n" +
                   unitsSoldString.Trim() + "\n" +
                   "Total: " + UnitsSoldByMonths.Sum(e => e.UnitsSold.Sum(f => f)) + "\n";
        }

        internal class UnitsSoldByMonth
        {
            public UnitsSoldByMonth(int count, int month, int year, IList<int> unitsSold)
            {
                UnitsSold = unitsSold;
                Month = month;
                Year = year;
                Count = count;
            }

            public UnitsSoldByMonth(int count, DateTime date, IList<int> unitsSold)
            {
                UnitsSold = unitsSold;
                Month = date.Month;
                Year = date.Year;
                Count = count;
            }

            public int Count { get; set; }

            public IList<int> UnitsSold { get; private set; }

            public int Month { get; private set; }
            public int Year { get; private set; }

        }
    }
}
