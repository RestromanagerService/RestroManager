using Microsoft.AspNetCore.Mvc;
using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class StockCommercialProductControllerTests
    {
        private Mock<IGenericUnitOfWork<StockCommercialProduct>> _mockGenericUnitOfWork;
        private Mock<IStockCommercialProductUnitOfWork> _mockStockCommercialProductUnitOfWork;
        private Mock<IFileStorage> _mockFileStorage;
        private StockCommercialProductController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<StockCommercialProduct>>();
            _mockStockCommercialProductUnitOfWork = new Mock<IStockCommercialProductUnitOfWork>();
            _mockFileStorage = new Mock<IFileStorage>();

            _controller = new StockCommercialProductController(
                _mockGenericUnitOfWork.Object,
                _mockStockCommercialProductUnitOfWork.Object,
                _mockFileStorage.Object
            );
        }

        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new List<StockCommercialProduct> { new StockCommercialProduct() };
            var actionResponse = new ActionResponse<IEnumerable<StockCommercialProduct>> { WasSuccess = true, Result = data };
            _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<IEnumerable<StockCommercialProduct>> { WasSuccess = false };
            _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_WithPagination_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<StockCommercialProduct> { new StockCommercialProduct() };
            var actionResponse = new ActionResponse<IEnumerable<StockCommercialProduct>> { WasSuccess = true, Result = data };
            _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_WithPagination_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<IEnumerable<StockCommercialProduct>> { WasSuccess = false };
            _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new StockCommercialProduct();
            var actionResponse = new ActionResponse<StockCommercialProduct> { WasSuccess = true, Result = data };
            _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(1), Times.Once());
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<StockCommercialProduct> { WasSuccess = false };
            _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(1), Times.Once());
        }

        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockStockCommercialProductUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockStockCommercialProductUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockStockCommercialProductUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockStockCommercialProductUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
    }
}
