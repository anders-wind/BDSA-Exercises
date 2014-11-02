using System;
using System.Linq;
using Northwind.DataStorage;
using NorthwindApplication.ViewModels;
using NUnit.Framework;

namespace NorthwindApplication.tests
{
    [TestFixture]
    public class OrdersViewModelTest
    {
        private OrdersViewModel ordersViewModel;
        private IDataStorage storage;

        [SetUp]
        public void setup()
        {
            storage = new DataStorageMock();
            ordersViewModel = new OrdersViewModel(storage);
        }

        [Test]
        public void TestGetOrders()
        {
            var tempList1 = ordersViewModel.GetOrders();
            var tempList2 = storage.Orders();
            Assert.AreEqual(tempList1.Count, tempList2.Count);
            var tempOrderViewModel = new OrderViewModel();
            for (int i = 0; i < tempList1.Count; i++)
            {
                Assert.AreEqual(tempList1[i], tempOrderViewModel.GetOrder(tempList2[i]));
            }
        }
    }
}