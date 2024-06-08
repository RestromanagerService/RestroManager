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
    public class ProductsControllerTest
    {
        //private Mock<IGenericUnitOfWork<Product>> _mockGenericUnitOfWork = null!;
        //private Mock<IProductUnitOfWork> _mockProductUnitOfWork = null!;
        //private ProductsController _controller = null!;
        //[TestInitialize]
        //public void Setup()
        //{
        //    _mockProductUnitOfWork = new Mock<IProductUnitOfWork>();
        //    _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Product>>();
        //    _controller = new ProductsController(_mockGenericUnitOfWork.Object, _mockProductUnitOfWork.Object);
        //
        //}
        //[TestMethod]
        //public async Task GetAsyncFull_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var data = new List<Product> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = true, Result = data };
        //    _mockProductUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync();
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockProductUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetAsyncFull_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var data = new List<Product> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = false };
        //    _mockProductUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync();
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockProductUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var data = new List<Product> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<Product>> {WasSuccess = true, Result=data};
        //    _mockProductUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockProductUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var data = new List<Product> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = false };
        //    _mockProductUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockProductUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
        //    _mockProductUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetPagesAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockProductUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var actionResponse = new ActionResponse<int> { WasSuccess = false };
        //    _mockProductUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetPagesAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockProductUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        //}
        ////desde acá
        //[TestMethod]
        //public async Task GetRecipesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var data = new List<Product> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = true, Result = data };
        //    _mockProductUnitOfWork.Setup(x => x.GetRecipesAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetRecipesAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockProductUnitOfWork.Verify(x => x.GetRecipesAsync(pagination), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetRecipesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var data = new List<Product> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = false };
        //    _mockProductUnitOfWork.Setup(x => x.GetRecipesAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetRecipesAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockProductUnitOfWork.Verify(x => x.GetRecipesAsync(pagination), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetRecipesTotalPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
        //    _mockProductUnitOfWork.Setup(x => x.GetRecipesTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetRecipesTotalPagesAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockProductUnitOfWork.Verify(x => x.GetRecipesTotalPagesAsync(pagination), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetRecipesTotalPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var actionResponse = new ActionResponse<int> { WasSuccess = false };
        //    _mockProductUnitOfWork.Setup(x => x.GetRecipesTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetRecipesTotalPagesAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockProductUnitOfWork.Verify(x => x.GetRecipesTotalPagesAsync(pagination), Times.Once());
        //}
        //
        //[TestMethod]
        //public async Task GetRecipesAsyncFull_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var data = new List<Product> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = true, Result = data };
        //    _mockProductUnitOfWork.Setup(x => x.GetRecipesAsync()).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetRecipesAsync();
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockProductUnitOfWork.Verify(x => x.GetRecipesAsync(), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetRecipesAsyncFull_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var data = new List<Product> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<Product>> { WasSuccess = false };
        //    _mockProductUnitOfWork.Setup(x => x.GetRecipesAsync()).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetRecipesAsync();
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockProductUnitOfWork.Verify(x => x.GetRecipesAsync(), Times.Once());
        //}
        //
        //[TestMethod]
        //public async Task GetAsyncById_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var data = new Product();
        //    var actionResponse = new ActionResponse<Product> { WasSuccess = true, Result = data };
        //    _mockProductUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync(2);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockProductUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetAsyncById_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var data = new Product();
        //    var actionResponse = new ActionResponse<Product> { WasSuccess = false };
        //    _mockProductUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync(2);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockProductUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        //}
        //
        //[TestMethod]
        //public async Task PutAsync_ReturnsOkObject_ModelNoOldPhoto()
        //{
        //    // Arrange
        //    Product product = new() { Name = "Bandeja Paisa" };
        //    var actionResponse = new ActionResponse<Product> { WasSuccess = true, Result = product };
        //    _mockProductUnitOfWork.Setup(x => x.UpdateAsync(product))
        //                  .ReturnsAsync(actionResponse);
        //    // Act
        //    var result = await _controller.PutAsync(product);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(product, okResult!.Value);
        //    _mockProductUnitOfWork.Verify(x => x.UpdateAsync(product), Times.Once());
        //}
        //[TestMethod]
        //public async Task PutAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    Product product = new() { Name = "Bandeja Paisa" };
        //    var actionResponse = new ActionResponse<Product> { WasSuccess = false };
        //    _mockProductUnitOfWork.Setup(x => x.UpdateAsync(product))
        //                  .ReturnsAsync(actionResponse);
        //    // Act
        //    var result = await _controller.PutAsync(product);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockProductUnitOfWork.Verify(x => x.UpdateAsync(product), Times.Once());
        //}

    }
}
