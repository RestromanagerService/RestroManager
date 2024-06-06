using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class TypeReportTest
    {
        [TestMethod]
        public void TypeReport_Id_GetSet()
        {
            // Arrange
            var typeReport = new TypeReport { Name = "Sample TypeReport" };
            var expected = 123;

            // Act
            typeReport.Id = expected;
            var actual = typeReport.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TypeReport_Name_GetSet()
        {
            // Arrange
            var typeReport = new TypeReport { Name = "Sample TypeReport" };
            var expected = "Updated TypeReport";

            // Act
            typeReport.Name = expected;
            var actual = typeReport.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
