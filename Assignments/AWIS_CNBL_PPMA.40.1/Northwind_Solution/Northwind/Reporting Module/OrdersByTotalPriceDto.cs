using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Reporting_Module
{
    class OrdersByTotalPriceDto
    {
        public OrdersByTotalPriceDto(int orderId, DateTime? orderDate, string customerContactName, decimal totalPriceWithDiscount, decimal totalPrice)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            CustomerContactName = customerContactName;
            TotalPriceWithDiscount = totalPriceWithDiscount;
            TotalPrice = totalPrice;
        }

        public int OrderId { get; private set; }
        public DateTime? OrderDate { get; private set; }
        public string CustomerContactName { get; private set; }
        public decimal TotalPriceWithDiscount { get; private set; }
        public decimal TotalPrice { get; private set; }

        public override string ToString()
        {
            return "OrderId | OrderDate | CustomerContactName | TotalPriceWithDiscount | TotalPrice " +
                   OrderId + " | " + OrderDate.Value.Date + " | " + CustomerContactName + " | " + TotalPriceWithDiscount + " | " + TotalPrice + "\n";
        }
    }
}
