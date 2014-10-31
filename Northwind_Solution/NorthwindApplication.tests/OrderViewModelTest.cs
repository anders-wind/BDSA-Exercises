using System;
using Northwind.DataStorage;
using Northwind.Reporting_Module;
using NorthwindApplication.ViewModels;
using NUnit.Framework;

namespace NorthwindApplication.tests
{
    [TestFixture]
    public class OrderViewModelTest
    {
        private OrderViewModel orderViewModel;
        [SetUp]
        public void setup()
        {
            orderViewModel = new OrderViewModel(new DataStorageMock());
        }
        [Test]
        public void TestGetOrder0()
        {
            var tempOrderView = orderViewModel.GetOrder(0);
            //Assert.AreEqual(0,orderViewModel.OrderID);
            //StringAssert.AreEqualIgnoringCase("Customer 0", orderViewModel.CustomerID);
        }
    }
}
