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
    public class ProductsControllerTests
    {
        private Mock<IGenericUnitOfWork<Product>> _mockGenericUnitOfWork;
        private Mock<IProductUnitOfWork> _mockProductUnitOfWork;
        private Mock<IFileStorage> _mockFileStorage;
        private ProductsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Product>>();
            _mockProductUnitOfWork = new Mock<IProductUnitOfWork>();
            _mockFileStorage = new Mock<IFileStorage>();

            _controller = new ProductsController(
                _mockGenericUnitOfWork.Object,
                _mockProductUnitOfWork.Object,
                _mockFileStorage.Object
            );
        }

        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new List<Product> { new Product() };
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = true, Result = data };
            _mockProductUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = false };
            _mockProductUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockProductUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_WithPagination_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<Product> { new Product() };
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = true, Result = data };
            _mockProductUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_WithPagination_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = false };
            _mockProductUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockProductUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetRecipesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<Product> { new Product() };
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = true, Result = data };
            _mockProductUnitOfWork.Setup(x => x.GetRecipesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetRecipesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetRecipesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetRecipesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = false };
            _mockProductUnitOfWork.Setup(x => x.GetRecipesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetRecipesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockProductUnitOfWork.Verify(x => x.GetRecipesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetRecipesTotalPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockProductUnitOfWork.Setup(x => x.GetRecipesTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetRecipesTotalPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetRecipesTotalPagesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetRecipesTotalPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockProductUnitOfWork.Setup(x => x.GetRecipesTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetRecipesTotalPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockProductUnitOfWork.Verify(x => x.GetRecipesTotalPagesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetRecipesFullAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new List<Product> { new Product() };
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = true, Result = data };
            _mockProductUnitOfWork.Setup(x => x.GetRecipesAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetRecipesAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetRecipesAsync(), Times.Once());
        }

        [TestMethod]
        public async Task GetRecipesFullAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = false };
            _mockProductUnitOfWork.Setup(x => x.GetRecipesAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetRecipesAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockProductUnitOfWork.Verify(x => x.GetRecipesAsync(), Times.Once());
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new Product();
            var actionResponse = new ActionResponse<Product> { WasSuccess = true, Result = data };
            _mockProductUnitOfWork.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetAsync(1), Times.Once());
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<Product> { WasSuccess = false, Message = "Error" };
            _mockProductUnitOfWork.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(actionResponse.Message, badRequestResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetAsync(1), Times.Once());
        }

        [TestMethod]
        public async Task GetProductsByType_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<Product> { new Product() };
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = true, Result = data };
            _mockProductUnitOfWork.Setup(x => x.GetProductsByType(It.IsAny<int>(), pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetProductsByType(1, pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetProductsByType(It.IsAny<int>(), pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetProductsByType_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = false, Message = "Error" };
            _mockProductUnitOfWork.Setup(x => x.GetProductsByType(It.IsAny<int>(), pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetProductsByType(1, pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(actionResponse.Message, badRequestResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetProductsByType(It.IsAny<int>(), pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetTotalProductsByType_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockProductUnitOfWork.Setup(x => x.GetTotalProductsByTypeAsync(It.IsAny<int>(), pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetTotalProductsByType(1, pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetTotalProductsByTypeAsync(It.IsAny<int>(), pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetTotalProductsByType_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false, Message = "Error" };
            _mockProductUnitOfWork.Setup(x => x.GetTotalProductsByTypeAsync(It.IsAny<int>(), pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetTotalProductsByType(1, pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(actionResponse.Message, badRequestResult!.Value);
            _mockProductUnitOfWork.Verify(x => x.GetTotalProductsByTypeAsync(It.IsAny<int>(), pagination), Times.Once());
        }
    }
}
