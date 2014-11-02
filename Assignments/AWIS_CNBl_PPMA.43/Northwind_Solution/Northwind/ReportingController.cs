using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind
{
    class ReportingController
    {
        /// <summary>
        /// Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public Report<IList<Order>, ReportError> TopOrdersByTotalPrice(int count)
        {
            using (var db = new NORTHWNDEntities())
            {
                IList<Order> topOrders = null;

                var ListOfTopOrders = from order in db.Orders
                                      select order;

                // get top results
                return new Report<IList<Order>, ReportError>(ListOfTopOrders.ToList(), null);
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
