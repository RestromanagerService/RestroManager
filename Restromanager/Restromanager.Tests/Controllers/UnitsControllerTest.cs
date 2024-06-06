using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class UnitsControllerTest
    {
        private Mock<IGenericUnitOfWork<Unit>> _mockGenericUnitOfWork = null!;
        private UnitsController _controller = null!;
        [TestMethod]
        public void constructor()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Unit>>();
            _controller = new UnitsController(_mockGenericUnitOfWork.Object);
        }
    }
}
