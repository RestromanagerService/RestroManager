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
    public class RawMaterialsControllerTest
    {
        private Mock<IGenericUnitOfWork<RawMaterial>> _mockGenericUnitOfWork = null!;
        private Mock<IRawMaterialsUnitOfWork> _mockRawMaterialUnitOfWork = null!;
        private RawMaterialsController _controller = null!;
        [TestInitialize]
        public void Setup()
        {
            _mockRawMaterialUnitOfWork = new Mock<IRawMaterialsUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<RawMaterial>>();
            _controller = new RawMaterialsController(_mockGenericUnitOfWork.Object, _mockRawMaterialUnitOfWork.Object);

        }
        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var comboData = new List<RawMaterial> { new() };
            var actionResponse = new ActionResponse<IEnumerable<RawMaterial>> {WasSuccess = true, Result=comboData};
            _mockRawMaterialUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockRawMaterialUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var comboData = new List<RawMaterial> { new() };
            var actionResponse = new ActionResponse<IEnumerable<RawMaterial>> { WasSuccess = false };
            _mockRawMaterialUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockRawMaterialUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockRawMaterialUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockRawMaterialUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockRawMaterialUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockRawMaterialUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
    }
}
