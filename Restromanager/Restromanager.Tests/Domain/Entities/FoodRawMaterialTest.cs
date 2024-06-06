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
    public class FoodRawMaterialTest
    {
        [TestMethod]
        public void FoodRawMaterial_Id_GetSet()
        {
            // Arrange
            var foodRawMaterial = new FoodRawMaterial { Amount = 1.0, UnitsId = 1 };
            var expected = 123;

            // Act
            foodRawMaterial.Id = expected;
            var actual = foodRawMaterial.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodRawMaterial_Amount_GetSet()
        {
            // Arrange
            var foodRawMaterial = new FoodRawMaterial { Amount = 1.0, UnitsId = 1 };
            var expected = 10.0;

            // Act
            foodRawMaterial.Amount = expected;
            var actual = foodRawMaterial.Amount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodRawMaterial_UnitsId_GetSet()
        {
            // Arrange
            var foodRawMaterial = new FoodRawMaterial { Amount = 1.0, UnitsId = 1 };
            var expected = 456;

            // Act
            foodRawMaterial.UnitsId = expected;
            var actual = foodRawMaterial.UnitsId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodRawMaterial_Units_GetSet()
        {
            // Arrange
            var foodRawMaterial = new FoodRawMaterial { Amount = 1.0, UnitsId = 1 };
            var expected = new Unit { Id = 1, Name = "Unit", Symbol = "U" };

            // Act
            foodRawMaterial.Units = expected;
            var actual = foodRawMaterial.Units;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodRawMaterial_FoodId_GetSet()
        {
            // Arrange
            var foodRawMaterial = new FoodRawMaterial { Amount = 1.0, UnitsId = 1 };
            var expected = 789;

            // Act
            foodRawMaterial.FoodId = expected;
            var actual = foodRawMaterial.FoodId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodRawMaterial_Food_GetSet()
        {
            // Arrange
            var foodRawMaterial = new FoodRawMaterial { Amount = 1.0, UnitsId = 1 };
            var expected = new Food { Id = 1, Name = "Food" };

            // Act
            foodRawMaterial.Food = expected;
            var actual = foodRawMaterial.Food;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodRawMaterial_RawMaterialId_GetSet()
        {
            // Arrange
            var foodRawMaterial = new FoodRawMaterial { Amount = 1.0, UnitsId = 1 };
            var expected = 987;

            // Act
            foodRawMaterial.RawMaterialId = expected;
            var actual = foodRawMaterial.RawMaterialId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FoodRawMaterial_RawMaterial_GetSet()
        {
            // Arrange
            var foodRawMaterial = new FoodRawMaterial { Amount = 1.0, UnitsId = 1 };
            var expected = new RawMaterial { Id = 1, Name = "RawMaterial" };

            // Act
            foodRawMaterial.RawMaterial = expected;
            var actual = foodRawMaterial.RawMaterial;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
