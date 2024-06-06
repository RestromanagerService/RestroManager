using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class TypeExpenseControllerTest
    {
        private Mock<IGenericUnitOfWork<TypeExpense>> _mockGenericUnitOfWork = null!;
        private TypeExpenseController _controller = null!;
        [TestMethod]
        public void constructor()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<TypeExpense>>();
            _controller = new TypeExpenseController(_mockGenericUnitOfWork.Object);
        }
    }
}
