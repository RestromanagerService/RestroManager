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
    public class CountriesControllerTest
    {
        private Mock<IGenericUnitOfWork<Country>> _mockGenericUnitOfWork = null!;
        private Mock<ICountriesUnitOfWork> _mockCountriesUnitOfWork = null!;
        private CountriesController _controller = null!;
        [TestInitialize]
        public void Setup()
        {
            _mockCountriesUnitOfWork = new Mock<ICountriesUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Country>>();
            _controller = new CountriesController(_mockGenericUnitOfWork.Object, _mockCountriesUnitOfWork.Object);

        }
        [TestMethod]
        public async Task GetAsyncFull_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new List<Country> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Country>> { WasSuccess = true, Result = data };
            _mockCountriesUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockCountriesUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncFull_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new List<Country> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Country>> { WasSuccess = false };
            _mockCountriesUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCountriesUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<Country> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Country>> { WasSuccess = true, Result = data };
            _mockCountriesUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockCountriesUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<IEnumerable<Country>> { WasSuccess = false };
            _mockCountriesUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCountriesUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockCountriesUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockCountriesUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockCountriesUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCountriesUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetComboAsync_ReturnsOkObject()
        {
            // Arrange
            var comboData = new List<Country> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Country>> { WasSuccess = true, Result = comboData };
            _mockCountriesUnitOfWork.Setup(x => x.GetComboAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetComboAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(comboData, okResult!.Value);
            _mockCountriesUnitOfWork.Verify(x => x.GetComboAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetComboAsync_ReturnsBadRequestObject()
        {
            // Arrange
            var comboData = new List<Country> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Country>> { WasSuccess = false };
            _mockCountriesUnitOfWork.Setup(x => x.GetComboAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetComboAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCountriesUnitOfWork.Verify(x => x.GetComboAsync(), Times.Once());
        }

        [TestMethod]
        public async Task GetAsyncById_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new Country();
            var actionResponse = new ActionResponse<Country> { WasSuccess = true, Result = data };
            _mockCountriesUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockCountriesUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncById_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new Country();
            var actionResponse = new ActionResponse<Country> { WasSuccess = false };
            _mockCountriesUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCountriesUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
    }
}
