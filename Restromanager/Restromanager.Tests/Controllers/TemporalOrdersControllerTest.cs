using Microsoft.AspNetCore.Mvc;
using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Http;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class TemporalOrdersControllerTests
    {
        private Mock<IGenericUnitOfWork<TemporalOrder>> _mockGenericUnitOfWork;
        private Mock<ITemporalOrdersUnitOfWork> _mockTemporalOrdersUnitOfWork;
        private TemporalOrdersController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<TemporalOrder>>();
            _mockTemporalOrdersUnitOfWork = new Mock<ITemporalOrdersUnitOfWork>();
            _controller = new TemporalOrdersController(_mockGenericUnitOfWork.Object, _mockTemporalOrdersUnitOfWork.Object);

            // Setting up a mock user identity
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "test@example.com")
            }, "mock"));

            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
        }

        [TestMethod]
        public async Task PostAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var temporalOrderDTO = new TemporalOrderDTO();
            var actionResponse = new ActionResponse<TemporalOrderDTO> { WasSuccess = true, Result = temporalOrderDTO };
            _mockTemporalOrdersUnitOfWork.Setup(x => x.AddFullAsync(It.IsAny<string>(), It.IsAny<TemporalOrderDTO>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.PostAsync(temporalOrderDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockTemporalOrdersUnitOfWork.Verify(x => x.AddFullAsync(It.IsAny<string>(), It.IsAny<TemporalOrderDTO>()), Times.Once());
        }

        [TestMethod]
        public async Task PostAsync_ReturnsBadRequestObjectResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var temporalOrderDTO = new TemporalOrderDTO();
            var actionResponse = new ActionResponse<TemporalOrderDTO> { WasSuccess = false, Message = "Error" };
            _mockTemporalOrdersUnitOfWork.Setup(x => x.AddFullAsync(It.IsAny<string>(), It.IsAny<TemporalOrderDTO>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.PostAsync(temporalOrderDTO);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(actionResponse.Message, badRequestResult!.Value);
            _mockTemporalOrdersUnitOfWork.Verify(x => x.AddFullAsync(It.IsAny<string>(), It.IsAny<TemporalOrderDTO>()), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var actionResponse = new ActionResponse<IEnumerable<TemporalOrder>> { WasSuccess = true, Result = new List<TemporalOrder>() };
            _mockTemporalOrdersUnitOfWork.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockTemporalOrdersUnitOfWork.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestObjectResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<IEnumerable<TemporalOrder>> { WasSuccess = false, Message = "Error" };
            _mockTemporalOrdersUnitOfWork.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(actionResponse.Message, badRequestResult!.Value);
            _mockTemporalOrdersUnitOfWork.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public async Task GetCountAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 5 };
            _mockTemporalOrdersUnitOfWork.Setup(x => x.GetCountAsync(It.IsAny<string>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetCountAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockTemporalOrdersUnitOfWork.Verify(x => x.GetCountAsync(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        public async Task GetCountAsync_ReturnsBadRequestObjectResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var actionResponse = new ActionResponse<int> { WasSuccess = false, Message = "Error" };
            _mockTemporalOrdersUnitOfWork.Setup(x => x.GetCountAsync(It.IsAny<string>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetCountAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual(actionResponse.Message, badRequestResult!.Value);
            _mockTemporalOrdersUnitOfWork.Verify(x => x.GetCountAsync(It.IsAny<string>()), Times.Once());
        }
    }
}
