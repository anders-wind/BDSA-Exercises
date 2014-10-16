using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                let customerContactName = TryGet(order)
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

        private string TryGet(Order order)
        {
            try
            {
                return order.Customer.ContactName;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Report<IList<ProductsBySaleDto>, ReportError> TopProductsBySale(int count)
        {
            var listOfProducts = _northwindController._products;

            IList<ProductsBySaleDto> ProductsBySaleDToList = from product in listOfProducts
                select product.Category;
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
