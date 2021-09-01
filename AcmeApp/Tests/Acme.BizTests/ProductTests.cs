﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            // Arrange
            var currentProduct = new Product()
            {
                ProductDescription = "A wood saw",
                ProductName = "Saw",
                ProductId = 1
            };
            var expected = $"Hello {currentProduct.ProductName} {currentProduct.ProductId}: {currentProduct.ProductDescription}";

            // Act
            var actual = currentProduct.SayHello();


            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SayHello_ParamaterizedConstructor()
        {
            // Arrange
            var currentProduct = new Product(1, "Saw", "A wood saw");
            var expected = $"Hello {currentProduct.ProductName} {currentProduct.ProductId}: {currentProduct.ProductDescription}";

            // Act
            var actual = currentProduct.SayHello();


            // Assert
            Assert.AreEqual(expected, actual);
        }
    
    }
}