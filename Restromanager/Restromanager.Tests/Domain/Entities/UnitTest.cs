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
    public class UnitTest
    {
        [TestMethod]
        public void Unit_Id_GetSet()
        {
            // Arrange
            var unit = new Unit { Name = "Sample Unit", Symbol = "SU" };
            var expected = 123;

            // Act
            unit.Id = expected;
            var actual = unit.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Unit_Name_GetSet()
        {
            // Arrange
            var unit = new Unit { Name = "Sample Unit", Symbol = "SU" };
            var expected = "Updated Unit";

            // Act
            unit.Name = expected;
            var actual = unit.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Unit_Symbol_GetSet()
        {
            // Arrange
            var unit = new Unit { Name = "Sample Unit", Symbol = "SU" };
            var expected = "UU";

            // Act
            unit.Symbol = expected;
            var actual = unit.Symbol;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
