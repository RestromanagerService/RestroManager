using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void Category_Id_GetSet()
        {
            // Arrange
            var category = new Category();
            var expected = 123;

            // Act
            category.Id = expected;
            var actual = category.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Category_Name_GetSet()
        {
            // Arrange
            var category = new Category();
            var expected = "Food Category";

            // Act
            category.Name = expected;
            var actual = category.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
