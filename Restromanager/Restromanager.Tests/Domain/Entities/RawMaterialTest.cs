using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class RawMaterialTest
    {
        [TestMethod]
        public void RawMaterial_Id_GetSet()
        {
            // Arrange
            var rawMaterial = new RawMaterial { Name = "Sample Raw Material" };
            var expected = 123;

            // Act
            rawMaterial.Id = expected;
            var actual = rawMaterial.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RawMaterial_Name_GetSet()
        {
            // Arrange
            var rawMaterial = new RawMaterial { Name = "Sample Raw Material" };
            var expected = "Updated Raw Material";

            // Act
            rawMaterial.Name = expected;
            var actual = rawMaterial.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RawMaterial_Photo_GetSet()
        {
            // Arrange
            var rawMaterial = new RawMaterial { Name = "Sample Raw Material" };
            var expected = "photo.jpg";

            // Act
            rawMaterial.Photo = expected;
            var actual = rawMaterial.Photo;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
