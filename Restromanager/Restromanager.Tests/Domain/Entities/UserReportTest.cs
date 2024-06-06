using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class UserReportTest
    {
        [TestMethod]
        public void UserReport_Id_GetSet()
        {
            // Arrange
            var userReport = new UserReport { Name = "Sample UserReport" };
            var expected = 123;

            // Act
            userReport.Id = expected;
            var actual = userReport.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserReport_Name_GetSet()
        {
            // Arrange
            var userReport = new UserReport { Name = "Sample UserReport" };
            var expected = "Updated UserReport";

            // Act
            userReport.Name = expected;
            var actual = userReport.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
