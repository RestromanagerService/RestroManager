using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Domain.Entities.Measures;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class UserReportsControllerTest
    {
        private Mock<IGenericUnitOfWork<UserReport>> _mockGenericUnitOfWork = null!;
        private UserReports _controller = null!;
        [TestMethod]
        public void constructor()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<UserReport>>();
            _controller = new UserReports(_mockGenericUnitOfWork.Object);
        }
    }
}
