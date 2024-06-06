using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class CityTest
    {
        [TestMethod]
        public void City_Id_GetSet()
        {
            // Arrange
            var city = new City();
            var expected = 123;

            // Act
            city.Id = expected;
            var actual = city.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void City_Name_GetSet()
        {
            // Arrange
            var city = new City();
            var expected = "Sample City";

            // Act
            city.Name = expected;
            var actual = city.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void City_StateId_GetSet()
        {
            // Arrange
            var city = new City();
            var expected = 456;

            // Act
            city.StateId = expected;
            var actual = city.StateId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void City_State_GetSet()
        {
            // Arrange
            var city = new City();
            var expected = new State { Id = 789, Name = "Sample State" };

            // Act
            city.State = expected;
            var actual = city.State;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
