using System.Collections.Generic;

namespace Northwind
{
    class ReportingController
    {
        /// <summary>
        /// Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        Report<IList<Order>, ReportError> TopOrdersByTotalPrice(int count)
        {
            IList<Order> topOrders = null;
            // get top results
            new Report<IList<Order>, ReportError>(null, topOrders);
            return null;
        }

        public class Report<TData, TError>
        {
            public TData Data { get; set; }
            public TError Error { get; set; }

            public Report(TError error, TData data)
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
