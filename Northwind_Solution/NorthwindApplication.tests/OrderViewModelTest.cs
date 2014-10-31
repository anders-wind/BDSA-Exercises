﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataStorage;
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
        public void TestMethod1()
        {
        }
    }
}
