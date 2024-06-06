using Microsoft.AspNetCore.Mvc;
using MimeKit.Cryptography;
using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;
using Restromanager.Backend.UnitsOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class FoodsControllerTest
    {
        private Mock<IGenericUnitOfWork<Food>> _mockGenericUnitOfWork = null!;
        private Mock<IFoodsUnitOfWork> _mockFoodsUnitOfWork = null!;
        private Mock<IFileStorage> _mockFileStorage= null!;
        private FoodsController _controller = null!;
        private readonly string _container = "foods";
        [TestInitialize]
        public void Setup()
        {
            _mockFoodsUnitOfWork = new Mock<IFoodsUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<Food>>();
            _mockFileStorage = new Mock<IFileStorage>();
            _controller = new FoodsController(_mockGenericUnitOfWork.Object,_mockFileStorage.Object, _mockFoodsUnitOfWork.Object);

        }
        [TestMethod]
        public async Task PutAsync_ReturnsOkObject_ModelContainsNewPhoto()
        {
            // Arrange
            Food food = new() { Photo = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8z8DAwMDAxMDAwMDAAAANHQEDasKb6QAAAABJRU5ErkJggg==" };
            var photoBase64 = Convert.FromBase64String(food.Photo!);
            var photoInStorage = "https://orderssebas20241.blob.core.windows.net/foods/testPhoto.jpg";
            Food foodUpdate = new Food { Photo = photoInStorage };
            var actionResponse = new ActionResponse<Food> { WasSuccess = true, Result = foodUpdate };
            _mockFileStorage.Setup(x => x.SaveFileAsync(photoBase64, ".jpg", _container)).ReturnsAsync(photoInStorage);
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(It.Is<Food>(f => f.Photo == photoInStorage)))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(food);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(foodUpdate, okResult!.Value);
            _mockFileStorage.Verify(x => x.SaveFileAsync(photoBase64, ".jpg", _container), Times.Once());
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(It.Is<Food>(f => f.Photo == photoInStorage)), Times.Once());
        }
        [TestMethod]
        public async Task PutAsync_ReturnsOkObject_ModelContainsOldPhoto()
        {
            // Arrange
            Food food = new() { Photo = "https://orderssebas20241.blob.core.windows.net/foods/testPhoto.jpg" };
            var actionResponse = new ActionResponse<Food> { WasSuccess = true, Result = food };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(food))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(food);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(food, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(food), Times.Once());
        }
        [TestMethod]
        public async Task PutAsync_ReturnsOkObject_ModelNoOldPhoto()
        {
            // Arrange
            Food food = new() { Name="Arroz" };
            var actionResponse = new ActionResponse<Food> { WasSuccess = true, Result = food };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(food))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(food);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(food, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(food), Times.Once());
        }
        [TestMethod]
        public async Task PutAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        {
            // Arrange
            Food food = new() { Name = "Arroz" };
            var actionResponse = new ActionResponse<Food> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(food))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(food);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(food), Times.Once());
        }
        [TestMethod]
        public async Task PostAsync_ReturnsOkObject_ModelContainsPhoto()
        {
            // Arrange
            Food food = new() { Photo = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8z8DAwMDAxMDAwMDAAAANHQEDasKb6QAAAABJRU5ErkJggg==" };
            var photoBase64 = Convert.FromBase64String(food.Photo!);
            var photoInStorage = "https://orderssebas20241.blob.core.windows.net/foods/testPhoto.jpg";
            Food foodUpdate = new Food { Photo = photoInStorage };
            var actionResponse = new ActionResponse<Food> { WasSuccess = true, Result = foodUpdate };
            _mockFileStorage.Setup(x => x.SaveFileAsync(photoBase64, ".jpg", _container)).ReturnsAsync(photoInStorage);
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(It.Is<Food>(f => f.Photo == photoInStorage)))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(food);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(foodUpdate, okResult!.Value);
            _mockFileStorage.Verify(x => x.SaveFileAsync(photoBase64, ".jpg", _container), Times.Once());
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(It.Is<Food>(f => f.Photo == photoInStorage)), Times.Once());
        }
        [TestMethod]
        public async Task PostAsync_ReturnsOkObject_ModelNoContainsPhoto()
        {
            // Arrange
            Food food = new() { Name="Arroz" };
            var actionResponse = new ActionResponse<Food> { WasSuccess = true, Result = food };
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(food))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(food);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(food, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(food), Times.Once());
        }
        [TestMethod]
        public async Task PostAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        {
            // Arrange
            Food food = new() { Name = "Arroz" };
            var actionResponse = new ActionResponse<Food> { WasSuccess = false};
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(food))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(food);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(food), Times.Once());
        }

        [TestMethod]
        public async Task GetAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var data = new List<Food> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Food>> { WasSuccess = true, Result = data };
            _mockFoodsUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockFoodsUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var comboData = new List<Food> { new() };
            var actionResponse = new ActionResponse<IEnumerable<Food>> { WasSuccess = false };
            _mockFoodsUnitOfWork.Setup(x => x.GetAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockFoodsUnitOfWork.Verify(x => x.GetAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = true, Result = 2 };
            _mockFoodsUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockFoodsUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }
        [TestMethod]
        public async Task GetPagesAsync_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var pagination = new PaginationDTO();
            var actionResponse = new ActionResponse<int> { WasSuccess = false };
            _mockFoodsUnitOfWork.Setup(x => x.GetTotalPagesAsync(pagination)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetPagesAsync(pagination);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockFoodsUnitOfWork.Verify(x => x.GetTotalPagesAsync(pagination), Times.Once());
        }

        [TestMethod]
        public async Task GetAsyncById_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new Food();
            var actionResponse = new ActionResponse<Food> { WasSuccess = true, Result = data };
            _mockFoodsUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockFoodsUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncById_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new Food();
            var actionResponse = new ActionResponse<Food> { WasSuccess = false };
            _mockFoodsUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockFoodsUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }


    }
   
}
