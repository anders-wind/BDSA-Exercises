using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Reporting_Module
{
    class UnitsSoldByMonth
    {
        public UnitsSoldByMonth(int count, int month, int year)
        {
            Month = month;
            Year = year;
            Count = count;
        }

        public UnitsSoldByMonth(int count, DateTime date)
        {
            Month = date.Month;
            Year = date.Year;
            Count = count;
        }

        public int Count { get; set; }
        private DateTime dateTimeMonth;
        private DateTime dateTimeYear;

        public int Month
        {
            get { return dateTimeMonth.Month; }
            set { dateTimeMonth = new DateTime(1,value,1); }
        }
        public int Year
        {
            get { return dateTimeYear.Year; }
            set { dateTimeMonth = new DateTime(value, 1, 1); }
        }

    }
}
