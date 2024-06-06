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
    public class StockRawMaterialTest
    {
        [TestMethod]
        public void StockRawMaterial_Id_GetSet()
        {
            // Arrange
            var stock = new StockRawMaterial { RawMaterialId = 1, Aumount = 10, UnitsId = 1, UnitCost = 5.0 };
            var expected = 123;

            // Act
            stock.Id = expected;
            var actual = stock.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StockRawMaterial_RawMaterialId_GetSet()
        {
            // Arrange
            var stock = new StockRawMaterial { RawMaterialId = 1, Aumount = 10, UnitsId = 1, UnitCost = 5.0 };
            var expected = 456;

            // Act
            stock.RawMaterialId = expected;
            var actual = stock.RawMaterialId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StockRawMaterial_RawMaterial_GetSet()
        {
            // Arrange
            var stock = new StockRawMaterial { RawMaterialId = 1, Aumount = 10, UnitsId = 1, UnitCost = 5.0 };
            var expected = new RawMaterial { Id = 1, Name = "Sample Raw Material" };

            // Act
            stock.RawMaterial = expected;
            var actual = stock.RawMaterial;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StockRawMaterial_Aumount_GetSet()
        {
            // Arrange
            var stock = new StockRawMaterial { RawMaterialId = 1, Aumount = 10, UnitsId = 1, UnitCost = 5.0 };
            var expected = 20.0;

            // Act
            stock.Aumount = expected;
            var actual = stock.Aumount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StockRawMaterial_UnitsId_GetSet()
        {
            // Arrange
            var stock = new StockRawMaterial { RawMaterialId = 1, Aumount = 10, UnitsId = 1, UnitCost = 5.0 };
            var expected = 789;

            // Act
            stock.UnitsId = expected;
            var actual = stock.UnitsId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StockRawMaterial_Units_GetSet()
        {
            // Arrange
            var stock = new StockRawMaterial { RawMaterialId = 1, Aumount = 10, UnitsId = 1, UnitCost = 5.0 };
            var expected = new Unit { Id = 1, Name = "Unit", Symbol = "U" };

            // Act
            stock.Units = expected;
            var actual = stock.Units;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StockRawMaterial_UnitCost_GetSet()
        {
            // Arrange
            var stock = new StockRawMaterial { RawMaterialId = 1, Aumount = 10, UnitsId = 1, UnitCost = 5.0 };
            var expected = 10.0;

            // Act
            stock.UnitCost = expected;
            var actual = stock.UnitCost;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
