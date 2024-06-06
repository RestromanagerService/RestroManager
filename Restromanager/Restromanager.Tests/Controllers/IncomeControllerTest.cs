using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class IncomeControllerTest
    {
        private Mock<IGenericUnitOfWork<Income>> _mockGenericUnitOfWork = null!;
        private IncomeController _controller = null!;
        [TestMethod]
        public void constructor()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Income>>();
            _controller = new IncomeController(_mockGenericUnitOfWork.Object);
        }
    }
}
