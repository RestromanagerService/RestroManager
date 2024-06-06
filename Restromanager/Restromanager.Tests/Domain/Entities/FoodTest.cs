using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class FoodTest
    {
        [TestMethod]
        public void Food_Id_GetSet()
        {
            // Arrange
            var food = new Food { Name = "Sample Food" };
            var expected = 123;

            // Act
            food.Id = expected;
            var actual = food.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Food_Name_GetSet()
        {
            // Arrange
            var food = new Food { Name = "Sample Food" };
            var expected = "Updated Food";

            // Act
            food.Name = expected;
            var actual = food.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Food_FoodRawMaterials_GetSet()
        {
            // Arrange
            var food = new Food { Name = "Sample Food" };
            var expected = new List<FoodRawMaterial> { new() { Amount =2}, new() { Amount = 3 } };

            // Act
            food.FoodRawMaterials = expected;
            var actual = food.FoodRawMaterials;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Food_FoodRawMaterialsNumber_CalculatedCorrectly()
        {
            // Arrange
            var food = new Food { Name = "Sample Food" };
            var foodRawMaterials = new List<FoodRawMaterial> { new() { Amount = 2 }, new() { Amount = 2 } };
            food.FoodRawMaterials = foodRawMaterials;

            // Act
            var actual = food.FoodRawMaterialsNumber;

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void Food_FoodRawMaterialsNumber_NoFoodRawMaterials()
        {
            // Arrange
            var food = new Food { Name = "Sample Food" };
            food.FoodRawMaterials = null;

            // Act
            var actual = food.FoodRawMaterialsNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Food_FoodRawMaterialsNumber_EmptyFoodRawMaterials()
        {
            // Arrange
            var food = new Food { Name = "Sample Food" };
            food.FoodRawMaterials = [];

            // Act
            var actual = food.FoodRawMaterialsNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Food_Photo_GetSet()
        {
            // Arrange
            var food = new Food { Name = "Sample Food" };
            var expected = "photo.jpg";

            // Act
            food.Photo = expected;
            var actual = food.Photo;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Food_ProductionCost_GetSet()
        {
            // Arrange
            var food = new Food { Name = "Sample Food" };
            var expected = 10.50;

            // Act
            food.ProductionCost = expected;
            var actual = food.ProductionCost;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
