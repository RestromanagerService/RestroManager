using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class ReportTest
    {
        [TestMethod]
        public void Report_Id_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = 123;

            // Act
            report.Id = expected;
            var actual = report.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_Name_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = "Updated Report";

            // Act
            report.Name = expected;
            var actual = report.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_Description_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = "Updated Description";

            // Act
            report.Description = expected;
            var actual = report.Description;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_CreatedDate_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = DateTime.Now.AddDays(1);

            // Act
            report.CreatedDate = expected;
            var actual = report.CreatedDate;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_UserReportId_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = 456;

            // Act
            report.UserReportId = expected;
            var actual = report.UserReportId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_UserReport_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = new UserReport { Id = 1, Name = "User Report" };

            // Act
            report.UserReport = expected;
            var actual = report.UserReport;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_TypeReportId_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = 789;

            // Act
            report.TypeReportId = expected;
            var actual = report.TypeReportId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_TypeReport_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = new TypeReport { Id = 1, Name = "Type Report" };

            // Act
            report.TypeReport = expected;
            var actual = report.TypeReport;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_ChartName_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = "Updated Chart Name";

            // Act
            report.ChartName = expected;
            var actual = report.ChartName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_LabelName_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = "Updated Label Name";

            // Act
            report.LabelName = expected;
            var actual = report.LabelName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Report_LabelValue_GetSet()
        {
            // Arrange
            var report = new Report
            {
                Name = "Sample Report",
                Description = "Sample Description",
                ChartName = "Sample Chart",
                CreatedDate = DateTime.Now,
                LabelName = "Sample Label",
                LabelValue = 100m,
                UserReportId = 1,
                TypeReportId = 1
            };
            var expected = 200m;

            // Act
            report.LabelValue = expected;
            var actual = report.LabelValue;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
