using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class StateTest
    {
        [TestMethod]
        public void State_Id_GetSet()
        {
            // Arrange
            var state = new State { Name = "Sample State", CountryId = 1 };
            var expected = 123;

            // Act
            state.Id = expected;
            var actual = state.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void State_Name_GetSet()
        {
            // Arrange
            var state = new State { Name = "Sample State", CountryId = 1 };
            var expected = "Updated State";

            // Act
            state.Name = expected;
            var actual = state.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void State_CountryId_GetSet()
        {
            // Arrange
            var state = new State { Name = "Sample State", CountryId = 1 };
            var expected = 456;

            // Act
            state.CountryId = expected;
            var actual = state.CountryId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void State_Country_GetSet()
        {
            // Arrange
            var state = new State { Name = "Sample State", CountryId = 1 };
            var expected = new Country { Id = 1, Name = "Sample Country" };

            // Act
            state.Country = expected;
            var actual = state.Country;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void State_Cities_GetSet()
        {
            // Arrange
            var state = new State { Name = "Sample State", CountryId = 1 };
            var expected = new List<City> { new City { Name = "City1", StateId = 1 }, new City { Name = "City2", StateId = 1 } };

            // Act
            state.Cities = expected;
            var actual = state.Cities;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void State_CitiesNumber_CalculatedCorrectly()
        {
            // Arrange
            var state = new State { Name = "Sample State", CountryId = 1 };
            var cities = new List<City> { new City { Name = "City1", StateId = 1 }, new City { Name = "City2", StateId = 1 } };
            state.Cities = cities;

            // Act
            var actual = state.CitiesNumber;

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void State_CitiesNumber_NoCities()
        {
            // Arrange
            var state = new State { Name = "Sample State", CountryId = 1 };
            state.Cities = null;

            // Act
            var actual = state.CitiesNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void State_CitiesNumber_EmptyCities()
        {
            // Arrange
            var state = new State { Name = "Sample State", CountryId = 1 };
            state.Cities = new List<City>();

            // Act
            var actual = state.CitiesNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }
    }
}
