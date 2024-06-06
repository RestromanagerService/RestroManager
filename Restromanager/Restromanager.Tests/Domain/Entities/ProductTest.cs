using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Product_Id_GetSet()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            var expected = 123;

            // Act
            product.Id = expected;
            var actual = product.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Product_Name_GetSet()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            var expected = "Updated Product";

            // Act
            product.Name = expected;
            var actual = product.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Product_ProductType_GetSet()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            var expected = ProductType.Commercial;

            // Act
            product.ProductType = expected;
            var actual = product.ProductType;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Product_ProductFoods_GetSet()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            var expected = new List<ProductFood> { new ProductFood { Amount = 1.0, UnitsId = 1 }, new ProductFood { Amount = 2.0, UnitsId = 1 } };

            // Act
            product.ProductFoods = expected;
            var actual = product.ProductFoods;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Product_ProductFoodsNumber_CalculatedCorrectly()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            var productFoods = new List<ProductFood> { new ProductFood { Amount = 1.0, UnitsId = 1 }, new ProductFood { Amount = 2.0, UnitsId = 1 } };
            product.ProductFoods = productFoods;

            // Act
            var actual = product.ProductFoodsNumber;

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void Product_ProductFoodsNumber_NoProductFoods()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            product.ProductFoods = null;

            // Act
            var actual = product.ProductFoodsNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Product_ProductFoodsNumber_EmptyProductFoods()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            product.ProductFoods = new List<ProductFood>();

            // Act
            var actual = product.ProductFoodsNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Product_ProductionCost_GetSet()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            var expected = 10.50;

            // Act
            product.ProductionCost = expected;
            var actual = product.ProductionCost;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Product_ProductCategories_GetSet()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            var expected = new List<ProductCategory> { new ProductCategory { ProductId = 1, CategoryId = 1 }, new ProductCategory { ProductId = 1, CategoryId = 2 } };

            // Act
            product.ProductCategories = expected;
            var actual = product.ProductCategories;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Product_ProductCategoriesNumber_CalculatedCorrectly()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            var productCategories = new List<ProductCategory> { new ProductCategory { ProductId = 1, CategoryId = 1 }, new ProductCategory { ProductId = 1, CategoryId = 2 } };
            product.ProductCategories = productCategories;

            // Act
            var actual = product.ProductCategoriesNumber;

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void Product_ProductCategoriesNumber_NoProductCategories()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            product.ProductCategories = null;

            // Act
            var actual = product.ProductCategoriesNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Product_ProductCategoriesNumber_EmptyProductCategories()
        {
            // Arrange
            var product = new Product { Name = "Sample Product" };
            product.ProductCategories = new List<ProductCategory>();

            // Act
            var actual = product.ProductCategoriesNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }
    }
}
