using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class ExpenseControllerTest
    {
        private Mock<IGenericUnitOfWork<Expense>> _mockGenericUnitOfWork = null!;
        private ExpenseController _controller = null!;
        [TestMethod]
        public void constructor()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Expense>>();
            _controller = new ExpenseController(_mockGenericUnitOfWork.Object);
        }
    }
}
