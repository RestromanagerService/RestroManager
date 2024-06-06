using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class IncomeTest
    {
        [TestMethod]
        public void Income_Id_GetSet()
        {
            // Arrange
            var income = new Income { Amount = 100m, Description = "Sample description" };
            var expected = 123;

            // Act
            income.Id = expected;
            var actual = income.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Income_Amount_GetSet()
        {
            // Arrange
            var income = new Income { Amount = 100m, Description = "Sample description" };
            var expected = 200m;

            // Act
            income.Amount = expected;
            var actual = income.Amount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Income_Description_GetSet()
        {
            // Arrange
            var income = new Income { Amount = 100m, Description = "Sample description" };
            var expected = "Updated description";

            // Act
            income.Description = expected;
            var actual = income.Description;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Income_TypeIncomeId_GetSet()
        {
            // Arrange
            var income = new Income { Amount = 100m, Description = "Sample description" };
            var expected = 456;

            // Act
            income.TypeIncomeId = expected;
            var actual = income.TypeIncomeId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Income_TypeIncome_GetSet()
        {
            // Arrange
            var income = new Income { Amount = 100m, Description = "Sample description" };
            var expected = new TypeIncome { Id = 1, Name = "TypeIncome" };

            // Act
            income.TypeIncome = expected;
            var actual = income.TypeIncome;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
