using System;
using System.Linq;
using Northwind.DataStorage;
using NorthwindApplication.ViewModels;
using NUnit.Framework;

namespace NorthwindApplication.tests
{
    [TestFixture]
    public class OrderDetailsViewModelTest
    {
        private OrderDetailViewModel orderDetailViewModel;
        private IDataStorage storage;
        [SetUp]
        public void setup()
        {
            storage = new DataStorageMock();
            orderDetailViewModel = new OrderDetailViewModel(storage);
        }

        [Test]
        public void TestGetOrderDetails0()
        {
            var tempList = orderDetailViewModel.GetOrderDetails(0);
            foreach (var tempOrderDetail in tempList)
            {
                Assert.AreEqual(0,tempOrderDetail.Discount);
                Assert.AreEqual(0, tempOrderDetail.Quantity);
                Assert.AreEqual(0, tempOrderDetail.UnitPrice);
                StringAssert.AreEqualIgnoringCase("product 0", tempOrderDetail.ProductName);
            }
        }

        [Test]
        public void TestGetOrderDetails1()
        {
            var tempList = orderDetailViewModel.GetOrderDetails(1);
            foreach (var tempOrderDetail in tempList)
            {
                Assert.AreEqual(0.1f, tempOrderDetail.Discount);
                Assert.AreEqual(1, tempOrderDetail.Quantity);
                Assert.AreEqual(1, tempOrderDetail.UnitPrice);
                StringAssert.AreEqualIgnoringCase("product 1", tempOrderDetail.ProductName);
            }
        }

        [Test]
        public void TestGetOrderDetails2()
        {
            var tempList = orderDetailViewModel.GetOrderDetails(2);
            foreach (var tempOrderDetail in tempList)
            {
                Assert.AreEqual(0.2f, tempOrderDetail.Discount);
                Assert.AreEqual(2, tempOrderDetail.Quantity);
                Assert.AreEqual(2, tempOrderDetail.UnitPrice);
                StringAssert.AreEqualIgnoringCase("product 2", tempOrderDetail.ProductName);
            }
        }

        [Test]
        public void TestGetOrderDetails3()
        {
            var tempList = orderDetailViewModel.GetOrderDetails(3);
            foreach (var tempOrderDetail in tempList)
            {
                Assert.AreEqual(0.3f, tempOrderDetail.Discount);
                Assert.AreEqual(3, tempOrderDetail.Quantity);
                Assert.AreEqual(3, tempOrderDetail.UnitPrice);
                StringAssert.AreEqualIgnoringCase("product 3", tempOrderDetail.ProductName);
            }
        }

        [Test]
        public void TestGetOrderDetailsOverloads()
        {
            for (int j = 0; j < 4; j++)
            {
                var tempList1 = orderDetailViewModel.GetOrderDetails(j);
                var tempList2 = orderDetailViewModel.GetOrderDetails(storage.getOrder(j).Order_Details.ToList());
                Assert.AreEqual(tempList1.Count, tempList2.Count);
                for (int i = 0; i < tempList1.Count; i++)
                {
                    Assert.AreEqual(tempList1[i].Discount, tempList2[i].Discount);
                    Assert.AreEqual(tempList1[i].Quantity, tempList2[i].Quantity);
                    Assert.AreEqual(tempList1[i].Quantity, tempList2[i].Quantity);
                    StringAssert.AreEqualIgnoringCase(tempList1[i].ProductName, tempList2[i].ProductName);
                }
            }
        }
    }
}
