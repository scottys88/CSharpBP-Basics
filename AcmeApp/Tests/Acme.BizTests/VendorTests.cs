﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Common;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {

        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PlaceOrderTest()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from Acme\r\nInstructions: Standard Delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 1);

            // Assert
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Success, actual.Success);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrder_NullProduct_exception()
        {
            // Arrange
            var vendor = new Vendor();

            // Act
            var actual = vendor.PlaceOrder(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PlaceOrder_QuantityNull_exception()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");

            // Act
            var actual = vendor.PlaceOrder(product, 0);
        }

        [TestMethod]
        public void PlaceOrder_3Parameters()
        {
            // Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order from Acme\r\nDeliver By:25/10/2021\r\nInstructions: Standard Delivery");

            // Act
            var actual = vendor.PlaceOrder(product, 1, new DateTimeOffset(2021, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            // Assert
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_WithAddress()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            OperationResult expected = new OperationResult(true, "Test With Address");

            var actual = vendor.PlaceOrder(product, quantity: 1, Vendor.IncludeAddress.Yes, Vendor.SendCopy.No);

            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
        [TestMethod()]
        public void PlaceOrderTest_WithAddressAndSendCopy()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            OperationResult expected = new OperationResult(true, "Test With Address With Copy");

            var actual = vendor.PlaceOrder(product, quantity: 1, Vendor.IncludeAddress.Yes, Vendor.SendCopy.Yes);

            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }

        [TestMethod()]
        public void PlaceOrderTest_NoDeliveryDate()
        {
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            OperationResult expected = new OperationResult(true, "Order from Acme\r\nInstructions: House");

            var actual = vendor.PlaceOrder(product, 1, instructions: "House");
    
            Assert.AreEqual(expected.Success, actual.Success);
            Assert.AreEqual(expected.Message, actual.Message);
        }
    }
}