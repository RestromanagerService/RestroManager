using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class TypesReportControllerTest
    {
        private Mock<IGenericUnitOfWork<TypeReport>> _mockGenericUnitOfWork = null!;
        private TypesReportController _controller = null!;
        [TestMethod]
        public void constructor()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<TypeReport>>();
            _controller = new TypesReportController(_mockGenericUnitOfWork.Object);
        }
    }
}
