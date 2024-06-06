using Microsoft.AspNetCore.Mvc;
using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;
using Restromanager.Backend.UnitsOfWork.Interfaces;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class StatesControllerTest
    {
        private Mock<IGenericUnitOfWork<State>> _mockGenericUnitOfWork = null!;
        private Mock<IStatesUnitOfWork> _mockStatesUnitOfWork = null!;
        private StatesController _controller = null!;
        [TestInitialize]
        public void Setup()
        {
            _mockStatesUnitOfWork = new Mock<IStatesUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<State>>();
            _controller = new StatesController(_mockGenericUnitOfWork.Object, _mockStatesUnitOfWork.Object);

        }
        [TestMethod]
        public async Task GetAsyncFull_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new List<State> { new() };
            var actionResponse = new ActionResponse<IEnumerable<State>> { WasSuccess = true, Result = data };
            _mockStatesUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStatesUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncFull_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new List<State> { new() };
            var actionResponse = new ActionResponse<IEnumerable<State>> { WasSuccess = false };
            _mockStatesUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStatesUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<State> { new() };
            var actionResponse = new ActionResponse<IEnumerable<State>> { WasSuccess = true, Result = data };
            _mockStatesUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStatesUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<IEnumerable<State>> { WasSuccess = false };
            _mockStatesUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStatesUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockStatesUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStatesUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockStatesUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStatesUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetAsyncById_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new State();
            var actionResponse = new ActionResponse<State> { WasSuccess = true, Result = data };
            _mockStatesUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStatesUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncById_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new State();
            var actionResponse = new ActionResponse<State> { WasSuccess = false };
            _mockStatesUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStatesUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }

        [TestMethod]
        public async Task GetComboAsync_ReturnsOkObject()
        {
            // Arrange
            var comboData = new List<State> { new() };
            var actionResponse = new ActionResponse<IEnumerable<State>> { WasSuccess = true, Result = comboData };
            _mockStatesUnitOfWork.Setup(x => x.GetComboAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetComboAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(comboData, okResult!.Value);
            _mockStatesUnitOfWork.Verify(x => x.GetComboAsync(1), Times.Once());
        }
        [TestMethod]
        public async Task GetComboAsync_ReturnsBadRequestObject()
        {
            // Arrange
            var comboData = new List<State> { new() };
            var actionResponse = new ActionResponse<IEnumerable<State>> { WasSuccess = false };
            _mockStatesUnitOfWork.Setup(x => x.GetComboAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetComboAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStatesUnitOfWork.Verify(x => x.GetComboAsync(1), Times.Once());
        }
    }
}
