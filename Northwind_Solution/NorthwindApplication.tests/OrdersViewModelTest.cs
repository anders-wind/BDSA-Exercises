using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataStorage;
using NorthwindApplication.ViewModels;
using NUnit.Framework;

namespace NorthwindApplication.tests
{
    [TestFixture]
    public class OrdersViewModelTest
    {
        private OrdersViewModel ordersViewModel;
        [SetUp]
        public void setup()
        {
            ordersViewModel = new OrdersViewModel(new DataStorageMock());
        }
        [Test]
        public void TestMethod1()
        {
        }
    }
}
