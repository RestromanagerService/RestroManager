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
    public class StockRawMaterialControllerTest
    {
        private Mock<IGenericUnitOfWork<StockRawMaterial>> _mockGenericUnitOfWork = null!;
        private Mock<IStockRawMaterialUnitOfWork> _mockStockRawMaterialUnitOfWork = null!;
        private StockRawMaterialController _controller = null!;
        [TestInitialize]
        public void Setup()
        {
            _mockStockRawMaterialUnitOfWork = new Mock<IStockRawMaterialUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<StockRawMaterial>>();
            _controller = new StockRawMaterialController(_mockGenericUnitOfWork.Object, _mockStockRawMaterialUnitOfWork.Object);

        }
        [TestMethod]
        public async Task GetAsyncFull_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new List<StockRawMaterial> { new() };
            var actionResponse = new ActionResponse<IEnumerable<StockRawMaterial>> { WasSuccess = true, Result = data };
            _mockStockRawMaterialUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStockRawMaterialUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncFull_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new List<StockRawMaterial> { new() };
            var actionResponse = new ActionResponse<IEnumerable<StockRawMaterial>> { WasSuccess = false };
            _mockStockRawMaterialUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStockRawMaterialUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }


        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<StockRawMaterial> { new() };
            var actionResponse = new ActionResponse<IEnumerable<StockRawMaterial>> {WasSuccess = true, Result=data};
            _mockStockRawMaterialUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStockRawMaterialUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<StockRawMaterial> { new() };
            var actionResponse = new ActionResponse<IEnumerable<StockRawMaterial>> { WasSuccess = false };
            _mockStockRawMaterialUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStockRawMaterialUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockStockRawMaterialUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStockRawMaterialUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockStockRawMaterialUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStockRawMaterialUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetAsyncById_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new StockRawMaterial();
            var actionResponse = new ActionResponse<StockRawMaterial> { WasSuccess = true, Result = data };
            _mockStockRawMaterialUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStockRawMaterialUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncById_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new StockRawMaterial();
            var actionResponse = new ActionResponse<StockRawMaterial> { WasSuccess = false };
            _mockStockRawMaterialUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStockRawMaterialUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
    }
}
