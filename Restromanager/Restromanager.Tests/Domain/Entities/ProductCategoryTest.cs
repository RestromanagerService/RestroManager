using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class ProductCategoryTest
    {
        [TestMethod]
        public void ProductCategory_Id_GetSet()
        {
            // Arrange
            var productCategory = new ProductCategory { ProductId = 1, CategoryId = 1 };
            var expected = 123;

            // Act
            productCategory.Id = expected;
            var actual = productCategory.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCategory_ProductId_GetSet()
        {
            // Arrange
            var productCategory = new ProductCategory { ProductId = 1, CategoryId = 1 };
            var expected = 456;

            // Act
            productCategory.ProductId = expected;
            var actual = productCategory.ProductId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCategory_CategoryId_GetSet()
        {
            // Arrange
            var productCategory = new ProductCategory { ProductId = 1, CategoryId = 1 };
            var expected = 789;

            // Act
            productCategory.CategoryId = expected;
            var actual = productCategory.CategoryId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCategory_Product_GetSet()
        {
            // Arrange
            var productCategory = new ProductCategory { ProductId = 1, CategoryId = 1 };
            var expected = new Product { Id = 1, Name = "Sample Product" };

            // Act
            productCategory.Product = expected;
            var actual = productCategory.Product;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductCategory_Category_GetSet()
        {
            // Arrange
            var productCategory = new ProductCategory { ProductId = 1, CategoryId = 1 };
            var expected = new Category { Id = 1, Name = "Sample Category" };

            // Act
            productCategory.Category = expected;
            var actual = productCategory.Category;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
