using Restromanager.Backend.Domain.Entities;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class ExpenseTest
    {
        [TestMethod]
        public void Expense_Id_GetSet()
        {
            // Arrange
            var expense = new Expense { Description = "Sample description" };
            var expected = 123;

            // Act
            expense.Id = expected;
            var actual = expense.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Expense_Amount_GetSet()
        {
            // Arrange
            var expense = new Expense { Description = "Sample description" };
            var expected = 100.50m;

            // Act
            expense.Amount = expected;
            var actual = expense.Amount;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Expense_Description_GetSet()
        {
            // Arrange
            var expense = new Expense { Description = "Sample description" };
            var expected = "Updated description";

            // Act
            expense.Description = expected;
            var actual = expense.Description;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Expense_TypeExpenseId_GetSet()
        {
            // Arrange
            var expense = new Expense { Description = "Sample description" };
            var expected = 456;

            // Act
            expense.TypeExpenseId = expected;
            var actual = expense.TypeExpenseId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Expense_TypeExpense_GetSet()
        {
            // Arrange
            var expense = new Expense { Description = "Sample description" };
            var expected = new TypeExpense { Id = 789, Name = "Sample TypeExpense" };

            // Act
            expense.TypeExpense = expected;
            var actual = expense.TypeExpense;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
