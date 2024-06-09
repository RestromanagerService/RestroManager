using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Enums;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;
using Restrommanager.Backend.Controllers;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Restrommanager.Tests.Controllers
{
    [TestClass]
    public class OrdersControllerTests
    {
        private Mock<IOrdersHelper> _mockOrdersHelper;
        private Mock<IOrderUnitOfWork> _mockOrdersUnitOfWork;
        private OrdersController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockOrdersHelper = new Mock<IOrdersHelper>();
            _mockOrdersUnitOfWork = new Mock<IOrderUnitOfWork>();
            _controller = new OrdersController(_mockOrdersHelper.Object, _mockOrdersUnitOfWork.Object);
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "test@example.com")
            }, "mock"));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        [TestMethod]
        public async Task GetAsync_ReturnsOk_WhenOrderExists()
        {
            // Arrange
            var order = new Order { Id = 1, TableId = 2, OrderStatus = OrderStatus.New };
            var actionResponse = new ActionResponse<Order> { WasSuccess = true, Result = order };
            _mockOrdersUnitOfWork.Setup(u => u.GetAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(order, okResult!.Value);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsNotFound_WhenOrderDoesNotExist()
        {
            // Arrange
            var actionResponse = new ActionResponse<Order> { WasSuccess = false, Message = "Order not found" };
            _mockOrdersUnitOfWork.Setup(u => u.GetAsync(1)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
            var notFoundResult = result as NotFoundObjectResult;
            Assert.AreEqual("Order not found", notFoundResult!.Value);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsOk_WhenUserOrdersExist()
        {
            // Arrange
            var orders = new List<Order> { new Order { Id = 1, TableId = 2, OrderStatus = OrderStatus.New } };
            var actionResponse = new ActionResponse<IEnumerable<Order>> { WasSuccess = true, Result = orders };
            _mockOrdersUnitOfWork.Setup(u => u.GetAsync("test@example.com", It.IsAny<PaginationDTO>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(new PaginationDTO());

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(orders, okResult!.Value);
        }

        [TestMethod]
        public async Task GetPagesAsync_ReturnsOk_WhenPagesExist()
        {
            // Arrange
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 5 };
            _mockOrdersUnitOfWork.Setup(u => u.GetTotalPagesAsync("test@example.com", It.IsAny<PaginationDTO>())).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(new PaginationDTO());

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(5, okResult!.Value);
        }

        [TestMethod]
        public async Task GetByStatusAsync_ReturnsOk_WhenOrdersWithStatusExist()
        {
            // Arrange
            var orders = new List<Order> { new Order { Id = 1, TableId = 2, OrderStatus = OrderStatus.New } };
            var actionResponse = new ActionResponse<IEnumerable<Order>> { WasSuccess = true, Result = orders };
            _mockOrdersUnitOfWork.Setup(u => u.GetByStatusAsync("New")).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetByStatusAsync("New");

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(orders, okResult!.Value);
        }
    }
}
