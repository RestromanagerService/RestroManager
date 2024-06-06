using Restromanager.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class TypeExpenseTest
    {
        [TestMethod]
        public void TypeExpense_Id_GetSet()
        {
            // Arrange
            var typeExpense = new TypeExpense { Name = "Sample TypeExpense" };
            var expected = 123;

            // Act
            typeExpense.Id = expected;
            var actual = typeExpense.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TypeExpense_Name_GetSet()
        {
            // Arrange
            var typeExpense = new TypeExpense { Name = "Sample TypeExpense" };
            var expected = "Updated TypeExpense";

            // Act
            typeExpense.Name = expected;
            var actual = typeExpense.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TypeExpense_Expenses_GetSet()
        {
            // Arrange
            var typeExpense = new TypeExpense { Name = "Sample TypeExpense" };
            var expected = new List<Expense> { new Expense { Amount = 10.0m, Description = "Expense1", TypeExpenseId = 1 }, new Expense { Amount = 20.0m, Description = "Expense2", TypeExpenseId = 1 } };

            // Act
            typeExpense.Expenses = expected;
            var actual = typeExpense.Expenses;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
