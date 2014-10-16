using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Reporting_Module
{
    internal class ReportingController
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

            var ordersByTotalPriceDtoList = (from order in ListOfOrders
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
                return new Report<IList<OrdersByTotalPriceDto>, ReportError>(ordersByTotalPriceDtoList.ToList(), null);
            }
            catch (Exception)
            {
                return new Report<IList<OrdersByTotalPriceDto>, ReportError>(null, new ReportError("Failed"));
            }
            foreach (var test in ordersByTotalPriceDtoList)
            {
                Console.WriteLine(test.OrderId);
            }
            // get top results
            //return new Report<ordersByTotalPriceDtoList, ReportError>(null, null);
            return null;
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
        }

        public class ReportError
        {
            public string errorMessage { get; set; }

            public ReportError(string errorMessage)
            {
                this.errorMessage = errorMessage;
            }
        }
    }
}