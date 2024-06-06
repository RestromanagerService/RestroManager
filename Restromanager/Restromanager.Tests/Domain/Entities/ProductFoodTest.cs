using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class ProductFoodTest
    {
        [TestMethod]
        public void ProductFood_Id_GetSet()
        {
            // Arrange
            var productFood = new ProductFood { Amount = 1.0, UnitsId = 1 };
            var expected = 123;

            // Act
            productFood.Id = expected;
            var actual = productFood.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductFood_Amount_GetSet()
        {
            // Arrange
            var productFood = new ProductFood { Amount = 1.0, UnitsId = 1 };
            var expected = 10.0;

            // Act
            productFood.Amount = expected;
            var actual = productFood.Amount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductFood_UnitsId_GetSet()
        {
            // Arrange
            var productFood = new ProductFood { Amount = 1.0, UnitsId = 1 };
            var expected = 456;

            // Act
            productFood.UnitsId = expected;
            var actual = productFood.UnitsId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductFood_Units_GetSet()
        {
            // Arrange
            var productFood = new ProductFood { Amount = 1.0, UnitsId = 1 };
            var expected = new Unit { Id = 1, Name = "Unit", Symbol = "U" };

            // Act
            productFood.Units = expected;
            var actual = productFood.Units;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductFood_ProductId_GetSet()
        {
            // Arrange
            var productFood = new ProductFood { Amount = 1.0, UnitsId = 1 };
            var expected = 789;

            // Act
            productFood.ProductId = expected;
            var actual = productFood.ProductId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductFood_Product_GetSet()
        {
            // Arrange
            var productFood = new ProductFood { Amount = 1.0, UnitsId = 1 };
            var expected = new Product { Id = 1, Name = "Product" };

            // Act
            productFood.Product = expected;
            var actual = productFood.Product;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductFood_FoodId_GetSet()
        {
            // Arrange
            var productFood = new ProductFood { Amount = 1.0, UnitsId = 1 };
            var expected = 987;

            // Act
            productFood.FoodId = expected;
            var actual = productFood.FoodId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductFood_Food_GetSet()
        {
            // Arrange
            var productFood = new ProductFood { Amount = 1.0, UnitsId = 1 };
            var expected = new Food { Id = 1, Name = "Food" };

            // Act
            productFood.Food = expected;
            var actual = productFood.Food;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
