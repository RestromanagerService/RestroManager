using Microsoft.AspNetCore.Mvc;
using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class ReportsControllerTest
    {
        private Mock<IGenericUnitOfWork<Report>> _mockGenericUnitOfWork = null!;
        private Mock<IReportsUnitOfWork> _mockReportsUnitOfWork = null!;
        private ReportsController _controller = null!;
        [TestInitialize]
        public void Setup()
        {
            _mockReportsUnitOfWork = new Mock<IReportsUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Report>>();
            _controller = new ReportsController(_mockGenericUnitOfWork.Object, _mockReportsUnitOfWork.Object);

        }
        [TestMethod]
        public async Task GetAsyncFull_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new List<Report> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Report>> { WasSuccess = true, Result = data };
            _mockReportsUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockReportsUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncFull_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new List<Report> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Report>> { WasSuccess = false };
            _mockReportsUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockReportsUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var comboData = new List<Report> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Report>> {WasSuccess = true, Result=comboData};
            _mockReportsUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockReportsUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var comboData = new List<Report> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Report>> { WasSuccess = false };
            _mockReportsUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockReportsUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockReportsUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockReportsUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockReportsUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockReportsUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetAsyncById_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new Report();
            var actionResponse = new ActionResponse<Report> { WasSuccess = true, Result = data };
            _mockReportsUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockReportsUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncById_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new Report();
            var actionResponse = new ActionResponse<Report> { WasSuccess = false };
            _mockReportsUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockReportsUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
    }
}
