using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var expected = $"Hello {currentProduct.ProductName} {currentProduct.ProductId}: {currentProduct.ProductDescription}, Available on: ";

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
            var expected = $"Hello {currentProduct.ProductName} {currentProduct.ProductId}: {currentProduct.ProductDescription}, Available on: ";

            // Act
            var actual = currentProduct.SayHello();


            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SayHello_ObjectInitializer()
        {
            var currentProduct = new Product()
            {
                ProductId = 1,
                ProductName = "Saw",
                ProductDescription = "A wood saw"
            };

            var expected = $"Hello {currentProduct.ProductName} {currentProduct.ProductId}: {currentProduct.ProductDescription}, Available on: ";

            var actual = currentProduct.SayHello();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Product_Null()
        {
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;

            var actual = companyName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertMetersToInchesTest()
        {
            var expected = 78.74;

            var actual = 2 * Product.InchesPerMeter;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinumumPriceTest_Default()
        {
            var currentProduct = new Product();
            var expected = .96m;

            var actual = currentProduct.MinimumPrice;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MinimumPriceTest_Bulk()
        {
            var currentProduct = new Product(1, "Bulk Saws", "Some saws");
            var expected = 9.99m;

            var actual = currentProduct.MinimumPrice;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductName_Format()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = " A big Hammer ";
            var expected = "A big Hammer";

            var actual = currentProduct.ProductName;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductName__TooLong()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = "A long time ago in a galaxy far, far away.";
            var expectedValidation = "Product Name cannot be more than 20 characters";
            string expectedProductName = null;

            var actual = currentProduct.ValidationMessage;

            Assert.AreEqual(expectedValidation, actual);
            Assert.AreEqual(expectedProductName, currentProduct.ProductName);
        }
        [TestMethod]
        public void ProductName__TooShort()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = "12";
            var expected = "Product Name must be at least 3 characters";
            string expectedProductName = null;

            var actual = currentProduct.ValidationMessage;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedProductName, currentProduct.ProductName);
        }
        [TestMethod]
        public void ProductName_JustRight()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = "Bandsaw";
            string expected = null;
            string expectedProductName = "Bandsaw";

            var actual = currentProduct.ValidationMessage;

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedProductName, currentProduct.ProductName);
        }

        [TestMethod]
        public void Category_DefaultValue()
        {
            var currentProduct = new Product();
            var expected = "Tools";

            var actual = currentProduct.Category;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Category_NewValue()
        {
            var currentProduct = new Product();
            var expected = "Timber";
            currentProduct.Category = "Timber";

            var actual = currentProduct.Category;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SequenceNumber_DefaultValue()
        {
            var currentProduct = new Product();
            var expected = 1;

            var actual = currentProduct.SequenceNumber;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCode_DefaultValue()
        {
            var currentProduct = new Product();
            var expected = $"{currentProduct.Category}-{currentProduct.SequenceNumber}";

            var actual = currentProduct.ProductCode;

            Assert.AreEqual(expected, actual);
        }
    }
}