using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class TypeIncomeControllerTest
    {
        private Mock<IGenericUnitOfWork<TypeIncome>> _mockGenericUnitOfWork = null!;
        private TypeIncomeController _controller = null!;
        [TestMethod]
        public void constructor()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<TypeIncome>>();
            _controller = new TypeIncomeController(_mockGenericUnitOfWork.Object);
        }
    }
}
