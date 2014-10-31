using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataStorage;
using NorthwindApplication.ViewModels;
using NUnit.Framework;

namespace NorthwindApplication.tests
{
    [TestFixture]
    public class OrderDetailsViewModelTest
    {
        private OrderDetailViewModel orderDetailViewModel;
        [SetUp]
        public void setup()
        {
            orderDetailViewModel = new OrderDetailViewModel(new DataStorageMock());
        }

        [Test]
        public void TestMethod1()
        {
        }
    }
}
