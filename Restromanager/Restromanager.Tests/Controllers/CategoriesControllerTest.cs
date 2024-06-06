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
    public class CategoriesControllerTest
    {
        private Mock<IGenericUnitOfWork<Category>> _mockGenericUnitOfWork = null!;
        private Mock<ICategoriesUnitOfWork> _mockCategoryUnitOfWork = null!;
        private CategoriesController _controller = null!;
        [TestInitialize]
        public void Setup()
        {
            _mockCategoryUnitOfWork = new Mock<ICategoriesUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Category>>();
            _controller = new CategoriesController(_mockGenericUnitOfWork.Object, _mockCategoryUnitOfWork.Object);

        }
        [TestMethod]
        public async Task GetComboAsync_ReturnsOkObject()
        {
            // Arrange
            var comboData = new List<Category> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Category>> { WasSuccess=true,Result=comboData };
            _mockCategoryUnitOfWork.Setup(x => x.GetComboAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetComboAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(comboData, okResult!.Value);
            _mockCategoryUnitOfWork.Verify(x => x.GetComboAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetComboAsync_ReturnsBadRequestObject()
        {
            // Arrange
            var comboData = new List<Category> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Category>> { WasSuccess = false};
            _mockCategoryUnitOfWork.Setup(x => x.GetComboAsync()).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetComboAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCategoryUnitOfWork.Verify(x => x.GetComboAsync(), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var comboData = new List<Category> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Category>> {WasSuccess = true, Result=comboData};
            _mockCategoryUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockCategoryUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var comboData = new List<Category> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Category>> { WasSuccess = false };
            _mockCategoryUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCategoryUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockCategoryUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockCategoryUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockCategoryUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockCategoryUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
    }
}
