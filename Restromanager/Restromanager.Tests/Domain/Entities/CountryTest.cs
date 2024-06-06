using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class CountryTest
    {
        [TestMethod]
        public void Country_Id_GetSet()
        {
            // Arrange
            var country = new Country();
            var expected = 123;

            // Act
            country.Id = expected;
            var actual = country.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Country_Name_GetSet()
        {
            // Arrange
            var country = new Country();
            var expected = "Sample Country";

            // Act
            country.Name = expected;
            var actual = country.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Country_States_GetSet()
        {
            // Arrange
            var country = new Country();
            var expected = new List<State> { new State { Id = 1, Name = "State1" }, new State { Id = 2, Name = "State2" } };

            // Act
            country.States = expected;
            var actual = country.States;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Country_StatesNumber_CalculatedCorrectly()
        {
            // Arrange
            var country = new Country();
            var states = new List<State> { new State { Id = 1, Name = "State1" }, new State { Id = 2, Name = "State2" } };
            country.States = states;

            // Act
            var actual = country.StatesNumber;

            // Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void Country_StatesNumber_NoStates()
        {
            // Arrange
            var country = new Country();
            country.States = null;

            // Act
            var actual = country.StatesNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void Country_StatesNumber_EmptyStates()
        {
            // Arrange
            var country = new Country();
            country.States = new List<State>();

            // Act
            var actual = country.StatesNumber;

            // Assert
            Assert.AreEqual(0, actual);
        }
    }
}
