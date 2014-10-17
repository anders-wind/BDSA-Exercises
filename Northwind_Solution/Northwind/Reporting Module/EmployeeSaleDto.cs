using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Reporting_Module
{
    class EmployeeSaleDto
    {
        public EmployeeSaleDto(string employeeName, int reportsToId, IList<OrderDto> orders)
        {
            EmployeeName = employeeName;
            ReportsToId = reportsToId;
            this.orders = orders;
        }

        public string EmployeeName { get; private set; }
        public int ReportsToId { get; private set; }
        public IList<OrderDto> orders { get; private set; }

        public override string ToString()
        {
            string tempOrders = "";
            foreach (var orderDto in orders)
            {
                tempOrders += orderDto.ToString() + "\n";
            }
            return "Employee name: " + EmployeeName + "\n" +
                   "Reports told: " + ReportsToId + "\n" + tempOrders + "\n";  
        }

        internal class OrderDto
        {
            public OrderDto(int orderId, DateTime? orderDate, IList<ProductDto> products, decimal totalPrice)
            {
                OrderId = orderId;
                OrderDate = orderDate;
                this.products = products;
                TotalPrice = totalPrice;
            }

            public int OrderId { get; private set; }
            public DateTime? OrderDate { get; private set; }
            public decimal TotalPrice { get; private set; }
            public IList<ProductDto> products { get; private set; }

            public override string ToString()
            {
                string tempProducts = "";
                foreach (var productDto in products)
                {
                    tempProducts += productDto.ToString() + "\n";
                }

                return "   Order Id: " + OrderId + "\n" +
                       "   Order Date: " + OrderDate.Value + "\n" +
                       "   Total price: " + TotalPrice + "\n" + 
                       tempProducts + "\n";
            }

            internal class ProductDto
            {
                public ProductDto(string productName, decimal unitPrice, int quantity)
                {
                    ProductName = productName;
                    UnitPrice = unitPrice;
                    Quantity = quantity;
                }

                public string ProductName { get; private set; }
                public decimal UnitPrice { get; private set; }
                public int Quantity { get; private set; }

                public override string ToString()
                {
                    return "   -   ProductName: " + ProductName + "\n" +
                           "   -   Unit Price: " + UnitPrice + "\n" +
                           "   -   Quantity: " + Quantity;
                }
            }
        }
    }
}
