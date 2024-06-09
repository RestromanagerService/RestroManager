using Microsoft.AspNetCore.Mvc;
using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class TablesControllerTests
    {
        private Mock<IGenericUnitOfWork<Table>> _mockGenericUnitOfWork;
        private TablesController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Table>>();
            _controller = new TablesController(_mockGenericUnitOfWork.Object);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new List<Table> { new Table() };
            var actionResponse = new ActionResponse<IEnumerable<Table>> { WasSuccess = true, Result = data };
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
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<IEnumerable<Table>> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_WithPagination_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<Table> { new Table() };
            var actionResponse = new ActionResponse<IEnumerable<Table>> { WasSuccess = true, Result = data };
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
        public async Task GetAsync_WithPagination_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<IEnumerable<Table>> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new Table();
            var actionResponse = new ActionResponse<Table> { WasSuccess = true, Result = data };
            _mockGenericUnitOfWork.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(actionResponse);

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
            var actionResponse = new ActionResponse<Table> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.GetAsync(1), Times.Once());
        }

        [TestMethod]
        public async Task PutAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var model = new Table();
            var actionResponse = new ActionResponse<Table> { WasSuccess = true, Result = model };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(It.IsAny<Table>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.PutAsync(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(It.IsAny<Table>()), Times.Once());
        }

        [TestMethod]
        public async Task PutAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var model = new Table();
            var actionResponse = new ActionResponse<Table> { WasSuccess = false, Message = "Error" };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(It.IsAny<Table>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.PutAsync(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(actionResponse.Message, badRequestResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(It.IsAny<Table>()), Times.Once());
        }

        [TestMethod]
        public async Task PostAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var model = new Table();
            var actionResponse = new ActionResponse<Table> { WasSuccess = true, Result = model };
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(It.IsAny<Table>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.PostAsync(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(It.IsAny<Table>()), Times.Once());
        }

        [TestMethod]
        public async Task PostAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var model = new Table();
            var actionResponse = new ActionResponse<Table> { WasSuccess = false, Message = "Error" };
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(It.IsAny<Table>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.PostAsync(model);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(actionResponse.Message, badRequestResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(It.IsAny<Table>()), Times.Once());
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsNoContentResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var actionResponse = new ActionResponse<Table> { WasSuccess = true };
            _mockGenericUnitOfWork.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.DeleteAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
            _mockGenericUnitOfWork.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once());
        }

        [TestMethod]
        public async Task DeleteAsync_ReturnsNotFoundResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<Table> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.DeleteAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            _mockGenericUnitOfWork.Verify(x => x.DeleteAsync(It.IsAny<int>()), Times.Once());
        }
    }
}
