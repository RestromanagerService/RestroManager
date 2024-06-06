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
    public class CitiesControllerTest
    {
        private Mock<IGenericUnitOfWork<City>> _mockGenericUnitOfWork = null!;
        private Mock<ICitiesUnitOfWork> _mockCitiesUnitOfWork = null!;
        private CitiesController _controller = null!;
        [TestInitialize]
        public void Setup()
        {
            _mockCitiesUnitOfWork = new Mock<ICitiesUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<City>>();
            _controller = new CitiesController(_mockGenericUnitOfWork.Object, _mockCitiesUnitOfWork.Object);

        }
        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<City> { new() };
            var actionResponse = new ActionResponse<IEnumerable<City>> { WasSuccess = true, Result = data };
            _mockCitiesUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockCitiesUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<IEnumerable<City>> { WasSuccess = false };
            _mockCitiesUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCitiesUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockCitiesUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockCitiesUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockCitiesUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCitiesUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetComboAsync_ReturnsOkObject()
        {
            // Arrange
            var comboData = new List<City> { new() };
            var actionResponse = new ActionResponse<IEnumerable<City>> { WasSuccess = true, Result = comboData };
            _mockCitiesUnitOfWork.Setup(x => x.GetComboAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetComboAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(comboData, okResult!.Value);
            _mockCitiesUnitOfWork.Verify(x => x.GetComboAsync(1), Times.Once());
        }
        [TestMethod]
        public async Task GetComboAsync_ReturnsBadRequestObject()
        {
            // Arrange
            var comboData = new List<City> { new() };
            var actionResponse = new ActionResponse<IEnumerable<City>> { WasSuccess = false };
            _mockCitiesUnitOfWork.Setup(x => x.GetComboAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetComboAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCitiesUnitOfWork.Verify(x => x.GetComboAsync(1), Times.Once());
        }
    }
}
