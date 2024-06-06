using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class TypeIncomeTest
    {
        [TestMethod]
        public void TypeIncome_Id_GetSet()
        {
            // Arrange
            var typeIncome = new TypeIncome { Name = "Sample TypeIncome" };
            var expected = 123;

            // Act
            typeIncome.Id = expected;
            var actual = typeIncome.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TypeIncome_Name_GetSet()
        {
            // Arrange
            var typeIncome = new TypeIncome { Name = "Sample TypeIncome" };
            var expected = "Updated TypeIncome";

            // Act
            typeIncome.Name = expected;
            var actual = typeIncome.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TypeIncome_Incomes_GetSet()
        {
            // Arrange
            var typeIncome = new TypeIncome { Name = "Sample TypeIncome" };
            var expected = new List<Income>
            {
                new Income { Amount = 10.0m, Description = "Income1", TypeIncomeId = 1 },
                new Income { Amount = 20.0m, Description = "Income2", TypeIncomeId = 1 }
            };

            // Act
            typeIncome.Incomes = expected;
            var actual = typeIncome.Incomes;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
