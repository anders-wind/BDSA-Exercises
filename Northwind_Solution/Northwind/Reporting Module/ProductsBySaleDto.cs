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
                unitsSoldString += "\n" + unitSold.UnitsSold.Sum(x=>x) + " | " + unitSold.Count + " | " + unitSold.UnitsSold.Average(x=>x) + " | " + unitSold.Month + " | " + unitSold.Year);
            }
            return "Product ID: " + ProductId + " Name " + ProductName + "\n" +
                   "Quantity | Count | Avg | Month | Year" + "\n" +
                   unitsSoldString.Trim();
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
            private DateTime dateTimeMonth;
            private DateTime dateTimeYear;

            public IList<int> UnitsSold { get; private set; }

            public int Month
            {
                get { return dateTimeMonth.Month; }
                set { dateTimeMonth = new DateTime(1, value, 1); }
            }
            public int Year
            {
                get { return dateTimeYear.Year; }
                set { dateTimeMonth = new DateTime(value, 1, 1); }
            }

        }
    }
}
