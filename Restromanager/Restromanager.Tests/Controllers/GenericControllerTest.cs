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
    public class GenericControllerTest
    {
        private Mock<IGenericUnitOfWork<Object>> _mockGenericUnitOfWork = null!;
        private GenericController<Object> _controller = null!;
        [TestInitialize]
        public void Setup()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Object>>();
            _controller = new GenericController<Object>(_mockGenericUnitOfWork.Object);

        }
        [TestMethod]
        public async Task GetFullAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new List<Object> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Object>> { WasSuccess = true, Result = data };
            _mockGenericUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetFullAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new List<Object> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Object>> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<Object> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Object>> {WasSuccess = true, Result=data};
            _mockGenericUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<Object> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Object>> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockGenericUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            Object data = new() ;
            var actionResponse = new ActionResponse<Object> { WasSuccess = true, Result = data };
            _mockGenericUnitOfWork.Setup(x => x.GetAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.GetAsync(1), Times.Once());
        }
        [TestMethod]
        public async Task GetByIdAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            Object data = new();
            var actionResponse = new ActionResponse<Object> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.GetAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.GetAsync(1), Times.Once());
        }

        [TestMethod]
        public async Task PutAsync_ReturnsOkObject()
        {
            // Arrange
            Object obj = new();
            var actionResponse = new ActionResponse<Object> { WasSuccess = true, Result = obj };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(obj))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(obj);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(obj, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(obj), Times.Once());
        }
        [TestMethod]
        public async Task PutAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        {
            // Arrange
            Object obj = new();
            var actionResponse = new ActionResponse<Object> { WasSuccess = false};
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(obj))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(obj);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(obj), Times.Once());
        }
        [TestMethod]
        public async Task PostAsync_ReturnsOkObject()
        {
            // Arrange
            Object obj = new();
            var actionResponse = new ActionResponse<Object> { WasSuccess = true, Result = obj };
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(obj))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(obj);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(obj, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(obj), Times.Once());
        }
        [TestMethod]
        public async Task PostAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        {
            // Arrange
            Object obj = new();
            var actionResponse = new ActionResponse<Object> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(obj))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(obj);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(obj), Times.Once());
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var actionResponse = new ActionResponse<Object> { WasSuccess = true };
            _mockGenericUnitOfWork.Setup(x => x.DeleteAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.DeleteAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
            _mockGenericUnitOfWork.Verify(x => x.DeleteAsync(1), Times.Once());
        }
        [TestMethod]
        public async Task DeleteAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<Object> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.DeleteAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.DeleteAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            _mockGenericUnitOfWork.Verify(x => x.DeleteAsync(1), Times.Once());
        }
    }
}
