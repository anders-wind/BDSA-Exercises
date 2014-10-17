using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Northwind.Reporting_Module
{
    class ReportingController
    {
        private NorthwindController _northwindController;

        public ReportingController(NorthwindController northwindController)
        {
            _northwindController = northwindController;
        }

        /// <summary>
        /// Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        {
            var ListOfOrders = _northwindController._orders;

            var ordersByTotalPriceDto = (from order in ListOfOrders
                let orderId = order.OrderID
                let orderDate = order.OrderDate
                let customerContactName = order.Customer.ContactName
                let totalPrice = (from od in order.Order_Details
                                    select od).Sum(od => od.UnitPrice*od.Quantity)
                let totalPriceWithDiscount = (from od in order.Order_Details
                                    select od).Sum(od => (od.UnitPrice*od.Quantity)*(decimal) (1 - od.Discount))
                orderby totalPrice descending
                select
                    new OrdersByTotalPriceDto(orderId, orderDate, customerContactName,
                        (decimal) totalPriceWithDiscount,
                        totalPrice)).Take(count);
            try
            {
                return new Report<IList<OrdersByTotalPriceDto>, ReportError>(ordersByTotalPriceDto.ToList(), null);
            }
            catch (Exception exception)
            {
                return new Report<IList<OrdersByTotalPriceDto>, ReportError>(null, new ReportError("Failed: " + exception.Message));
            }
        }

        public Report<IList<ProductsBySaleDto>, ReportError> TopProductsBySale(int count)
        {
            var listOfProducts = _northwindController._products;

            var ProductsBySaleDToList = (from product in listOfProducts
                let ProductId = product.ProductID
                let ProductName = product.ProductName
                let orderDetailsPerMonth = (from unitSoldByMonth in product.Order_Details
                                        group unitSoldByMonth by unitSoldByMonth.Order.OrderDate)
                let unitsSoldByMonth = (from test in orderDetailsPerMonth
                            let county = test.Count()
                            let quantity = (IList<int>)test.Select(e=>(Int32)e.Quantity).ToList()
                            let date = test.Key
                            orderby quantity.Sum(e=>e) descending 
                            select new ProductsBySaleDto.UnitsSoldByMonth(county,date.Value,quantity))
                
                select new ProductsBySaleDto(ProductId,ProductName, unitsSoldByMonth.ToList())).Take(count);


            try
            {
                return new Report<IList<ProductsBySaleDto>, ReportError>(ProductsBySaleDToList.ToList(), null);
            }
            catch (Exception exception)
            {
                return new Report<IList<ProductsBySaleDto>, ReportError>(null, new ReportError("Failed: " + exception.Message));
            }
        }

        public Report<EmployeeSaleDto, ReportError> EmployeeSale(int id)
        {
            var listOfEmployees = _northwindController._employee;
            var employeesSaleDto = (from employee in listOfEmployees
                                    where employee.EmployeeID == id
                let employeeName = employee.FirstName + " " + employee.LastName
                let reportsTold = employee.Orders.Count
                let orders = (from order in employee.Orders
                    let products = (from order_Details in order.Order_Details
                        let product = order_Details.Product
                        select
                            new EmployeeSaleDto.OrderDto.ProductDto(product.ProductName,
                                product.UnitPrice.GetValueOrDefault(), order_Details.Quantity)).ToList()
                    let totalPrice = (from order_Details in order.Order_Details
                        select order_Details).Sum(order_Details => order_Details.UnitPrice)
                    select new EmployeeSaleDto.OrderDto(order.OrderID, order.OrderDate, products, (decimal) totalPrice)).ToList()
                select new EmployeeSaleDto(employeeName,reportsTold,orders));
            try
            {
                return new Report<EmployeeSaleDto, ReportError>(employeesSaleDto.ToList().First(), null);
            }
            catch (Exception exception)
            {
                return new Report<EmployeeSaleDto, ReportError>(null, new ReportError("Failed: " + exception.Message));
            }
        }

        public class Report<TData, TError>
        {
            public TData Data { get; set; }
            public TError Error { get; set; }

            public Report(TData data, TError error)
            {
                Error = error;
                Data = data;
            }

            public override string ToString()
            {
                if (Data == null) return Error.ToString();
                if (Data is IList)
                {
                    string tempstring = "";
                    foreach (var dataToString in (IList)Data)
                    {
                        tempstring += dataToString + "\n";
                    }
                    return tempstring;
                }
                return Data.ToString();
            }
        }

        public class ReportError
        {
            public string errorMessage { get; set; }

            public ReportError(string errorMessage)
            {
                this.errorMessage = errorMessage;
            }

            public override string ToString()
            {
                return errorMessage;
            }
        }
    }
}
