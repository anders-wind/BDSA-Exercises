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
        private IDataStorage storage;
        [SetUp]
        public void setup()
        {
            storage = new DataStorageMock();
            orderViewModel = new OrderViewModel(storage);
        }
        [Test]
        public void TestGetOrder0()
        {
            var tempOrderView = orderViewModel.GetOrder(0);
            Assert.AreEqual(0, tempOrderView.OrderID);
            Assert.AreEqual(null, tempOrderView.OrderDate);
            StringAssert.AreEqualIgnoringCase("Customer 0", tempOrderView.CustomerID);
            StringAssert.AreEqualIgnoringCase("firstname 0 lastname 0", tempOrderView.EmployeeID);
            StringAssert.AreEqualIgnoringCase("address 0",tempOrderView.ShipAddress);
            StringAssert.AreEqualIgnoringCase("city 0", tempOrderView.ShipCity);
            StringAssert.AreEqualIgnoringCase("country 0", tempOrderView.ShipCountry);
            StringAssert.AreEqualIgnoringCase("name 0", tempOrderView.ShipName);
            StringAssert.AreEqualIgnoringCase("region 0", tempOrderView.ShipRegion);
            StringAssert.AreEqualIgnoringCase("pc 0", tempOrderView.ShipPostalCode);
            Assert.AreEqual(0, tempOrderView.TotalPrice);
        }

        [Test]
        public void TestGetOrder1()
        {
            var tempOrderView = orderViewModel.GetOrder(1);
            Assert.AreEqual(1, tempOrderView.OrderID);
            Assert.AreEqual(new DateTime(1,1,1), tempOrderView.OrderDate);
            StringAssert.AreEqualIgnoringCase("Customer 1", tempOrderView.CustomerID);
            StringAssert.AreEqualIgnoringCase("firstname 1 lastname 1", tempOrderView.EmployeeID);
            StringAssert.AreEqualIgnoringCase("address 1", tempOrderView.ShipAddress);
            StringAssert.AreEqualIgnoringCase("city 1", tempOrderView.ShipCity);
            StringAssert.AreEqualIgnoringCase("country 1", tempOrderView.ShipCountry);
            StringAssert.AreEqualIgnoringCase("name 1", tempOrderView.ShipName);
            StringAssert.AreEqualIgnoringCase("region 1", tempOrderView.ShipRegion);
            StringAssert.AreEqualIgnoringCase("pc 1", tempOrderView.ShipPostalCode);
            Assert.AreEqual(1.8m, tempOrderView.TotalPrice);
        }

        [Test]
        public void TestGetOrder2()
        {
            var tempOrderView = orderViewModel.GetOrder(2);
            Assert.AreEqual(2, tempOrderView.OrderID);
            Assert.AreEqual(new DateTime(2, 2, 2), tempOrderView.OrderDate);
            StringAssert.AreEqualIgnoringCase("Customer 2", tempOrderView.CustomerID);
            StringAssert.AreEqualIgnoringCase("firstname 2 lastname 2", tempOrderView.EmployeeID);
            StringAssert.AreEqualIgnoringCase("address 2", tempOrderView.ShipAddress);
            StringAssert.AreEqualIgnoringCase("city 2", tempOrderView.ShipCity);
            StringAssert.AreEqualIgnoringCase("country 2", tempOrderView.ShipCountry);
            StringAssert.AreEqualIgnoringCase("name 2", tempOrderView.ShipName);
            StringAssert.AreEqualIgnoringCase("region 2", tempOrderView.ShipRegion);
            StringAssert.AreEqualIgnoringCase("pc 2", tempOrderView.ShipPostalCode);
            Assert.AreEqual(3.2m, tempOrderView.TotalPrice);
        }
        [Test]
        public void TestGetOrder3()
        {
            var tempOrderView = orderViewModel.GetOrder(3);
            Assert.AreEqual(3, tempOrderView.OrderID);
            Assert.AreEqual(new DateTime(3, 3, 3), tempOrderView.OrderDate);
            StringAssert.AreEqualIgnoringCase("Customer 3", tempOrderView.CustomerID);
            StringAssert.AreEqualIgnoringCase("firstname 3 lastname 3", tempOrderView.EmployeeID);
            StringAssert.AreEqualIgnoringCase("address 3", tempOrderView.ShipAddress);
            StringAssert.AreEqualIgnoringCase("city 3", tempOrderView.ShipCity);
            StringAssert.AreEqualIgnoringCase("country 3", tempOrderView.ShipCountry);
            StringAssert.AreEqualIgnoringCase("name 3", tempOrderView.ShipName);
            StringAssert.AreEqualIgnoringCase("region 3", tempOrderView.ShipRegion);
            StringAssert.AreEqualIgnoringCase("pc 3", tempOrderView.ShipPostalCode);
            Assert.AreEqual(6.3m, tempOrderView.TotalPrice);
        }

        [Test]
        public void TestGetOrderOverload()
        {
            Assert.AreEqual(orderViewModel.GetOrder(0), orderViewModel.GetOrder(storage.getOrder(0)));
            Assert.AreEqual(orderViewModel.GetOrder(1), orderViewModel.GetOrder(storage.getOrder(1)));
            Assert.AreEqual(orderViewModel.GetOrder(2), orderViewModel.GetOrder(storage.getOrder(2)));
            Assert.AreEqual(orderViewModel.GetOrder(3), orderViewModel.GetOrder(storage.getOrder(3)));
        }
    }
}
