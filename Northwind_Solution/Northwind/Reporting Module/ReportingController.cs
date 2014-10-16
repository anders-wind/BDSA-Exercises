using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Reporting_Module
{
    class ReportingController
    {
        /// <summary>
        /// Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        {
            using (var db = new NORTHWNDEntities())
            {
                IList<Order> topOrders = null;

                var ListOfOrders = from order in db.Orders
                                      select order;

                var ListOfOrderDetails = from orderDetail in db.Order_Details
                                            select orderDetail;

                IList<OrdersByTotalPriceDto> ordersByTotalPriceDtoList = (from order in ListOfOrders
                    let orderId = order.OrderID
                    let orderDate = order.OrderDate
                    let customerContactName = order.Customer.ContactName

                    let totalPriceWithDiscountGet = (from orderDetail in ListOfOrderDetails
                        let totalPriceWithDiscount =
                            orderDetail.UnitPrice*orderDetail.Quantity*((decimal) (1 - orderDetail.Discount))
                        select totalPriceWithDiscount).SingleOrDefault()

                    let totalPrice = (from orderDetail in ListOfOrderDetails
                        let totalPrice = orderDetail.UnitPrice*orderDetail.Quantity
                        select totalPrice).SingleOrDefault()

                    orderby totalPrice descending 
                    select
                        new OrdersByTotalPriceDto(orderId, orderDate, customerContactName, totalPriceWithDiscountGet,
                            totalPrice)).ToList();

                foreach (var test in ordersByTotalPriceDtoList)
                {
                    Console.WriteLine(test.OrderId);
                }
                // get top results
                //return new Report<ordersByTotalPriceDtoList, ReportError>(null, null);
                return null;
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
