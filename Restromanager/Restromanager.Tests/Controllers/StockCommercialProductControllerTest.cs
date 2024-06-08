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
    public class StockCommercialProductControllerTest
    {
        //private Mock<IGenericUnitOfWork<StockCommercialProduct>> _mockGenericUnitOfWork = null!;
        //private Mock<IStockCommercialProductUnitOfWork> _mockStockCommercialProductUnitOfWork = null!;
        //private StockCommercialProductController _controller = null!;
        //[TestInitialize]
        //public void Setup()
        //{
        //    _mockStockCommercialProductUnitOfWork = new Mock<IStockCommercialProductUnitOfWork>();
        //    _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<StockCommercialProduct>>();
        //    _controller = new StockCommercialProductController(_mockGenericUnitOfWork.Object, _mockStockCommercialProductUnitOfWork.Object);
        //
        //}
        //[TestMethod]
        //public async Task GetAsyncFull_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var data = new List<StockCommercialProduct> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<StockCommercialProduct>> { WasSuccess = true, Result = data };
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync();
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetAsyncFull_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var data = new List<StockCommercialProduct> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<StockCommercialProduct>> { WasSuccess = false };
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync()).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync();
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(), Times.Once());
        //}
        //
        //
        //[TestMethod]
        //public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var data = new List<StockCommercialProduct> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<StockCommercialProduct>> {WasSuccess = true, Result=data};
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var data = new List<StockCommercialProduct> { new() };
        //    var actionResponse = new ActionResponse<IEnumerable<StockCommercialProduct>> { WasSuccess = false };
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetPagesAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var pagination = new PaginationDTO();
        //    var actionResponse = new ActionResponse<int> { WasSuccess = false };
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetPagesAsync(pagination);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        //}
        //
        //[TestMethod]
        //public async Task GetAsyncById_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        //{
        //    // Arrange
        //    var data = new StockCommercialProduct();
        //    var actionResponse = new ActionResponse<StockCommercialProduct> { WasSuccess = true, Result = data };
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync(2);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(actionResponse.Result, okResult!.Value);
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        //}
        //[TestMethod]
        //public async Task GetAsyncById_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    var data = new StockCommercialProduct();
        //    var actionResponse = new ActionResponse<StockCommercialProduct> { WasSuccess = false };
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);
        //
        //    // Act
        //    var result = await _controller.GetAsync(2);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        //}
        //[TestMethod]
        //public async Task PutAsync_ReturnsOkObject_ModelNoOldPhoto()
        //{
        //    // Arrange
        //    StockCommercialProduct stockCommercialProduct = new() { ProductId=2 };
        //    var actionResponse = new ActionResponse<StockCommercialProduct> { WasSuccess = true, Result = stockCommercialProduct };
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.UpdateAsync(stockCommercialProduct))
        //                  .ReturnsAsync(actionResponse);
        //    // Act
        //    var result = await _controller.PutAsync(stockCommercialProduct);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        //    var okResult = result as OkObjectResult;
        //    Assert.AreEqual(stockCommercialProduct, okResult!.Value);
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.UpdateAsync(stockCommercialProduct), Times.Once());
        //}
        //[TestMethod]
        //public async Task PutAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        //{
        //    // Arrange
        //    StockCommercialProduct stockCommercialProduct = new() { ProductId = 2 };
        //    var actionResponse = new ActionResponse<StockCommercialProduct> { WasSuccess = false };
        //    _mockStockCommercialProductUnitOfWork.Setup(x => x.UpdateAsync(stockCommercialProduct))
        //                  .ReturnsAsync(actionResponse);
        //    // Act
        //    var result = await _controller.PutAsync(stockCommercialProduct);
        //
        //    // Assert
        //    Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        //    _mockStockCommercialProductUnitOfWork.Verify(x => x.UpdateAsync(stockCommercialProduct), Times.Once());
        //}
    }
}
