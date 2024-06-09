using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restromanager.Backend.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class TypeReportTest
    {
        [TestMethod]
        public void TypeReport_Id_GetSet()
        {
            // Arrange
            var typeReport = new TypeReport();
            var expected = 1;

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
            var typeReport = new TypeReport();
            var expected = "Financial Report";

            // Act
            typeReport.Name = expected;
            var actual = typeReport.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TypeReport_Name_MaxLength()
        {
            // Arrange
            var typeReport = new TypeReport();
            var invalidName = new string('a', 256); // 256 characters, exceeding the limit

            // Act & Assert
            var context = new ValidationContext(typeReport) { MemberName = "Name" };
            var result = new List<ValidationResult>();
            typeReport.Name = invalidName;
            var isValid = Validator.TryValidateProperty(typeReport.Name, context, result);

            Assert.IsFalse(isValid);
            Assert.AreEqual("El campo Tipo de Reporte no puede tener más de 255 caracteres.", result.First().ErrorMessage);
        }

        [TestMethod]
        public void TypeReport_Name_Required()
        {
            // Arrange
            var typeReport = new TypeReport();
            typeReport.Name = null;

            // Act & Assert
            var context = new ValidationContext(typeReport) { MemberName = "Name" };
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateProperty(typeReport.Name, context, result);

            Assert.IsFalse(isValid);
            Assert.AreEqual("El campo Tipo de Reporte es requerido.", result.First().ErrorMessage);
        }
    }
}
