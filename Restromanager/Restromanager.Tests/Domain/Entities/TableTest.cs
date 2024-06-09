using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restromanager.Backend.Domain.Entities;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class TableTest
    {
        [TestMethod]
        public void Table_Id_GetSet()
        {
            // Arrange
            var table = new Table();
            var expected = 1;

            // Act
            table.Id = expected;
            var actual = table.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Table_Name_GetSet()
        {
            // Arrange
            var table = new Table();
            var expected = "Table 1";

            // Act
            table.Name = expected;
            var actual = table.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
