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

                var OrdersByTotalPriceDtoList = from order in ListOfOrders
                                                let 
                
                // get top results
                return new Report<IList<OrdersByTotalPriceDto>, ReportError>(null, null);
                //return null;
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
