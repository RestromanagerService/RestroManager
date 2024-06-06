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
    public class ProductProductFoodControllerTest
    {
        private Mock<IGenericUnitOfWork<ProductFood>> _mockGenericUnitOfWork = null!;
        private Mock<IProductFoodUnitOfWork> _mockProductFoodsUnitOfWork = null!;
        private Mock<IFileStorage> _mockFileStorage= null!;
        private ProductFoodController _controller = null!;
        private readonly string _container = "foods";
        [TestInitialize]
        public void Setup()
        {
            _mockProductFoodsUnitOfWork = new Mock<IProductFoodUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<ProductFood>>();
            _mockFileStorage = new Mock<IFileStorage>();
            _controller = new ProductFoodController(_mockGenericUnitOfWork.Object, _mockProductFoodsUnitOfWork.Object, _mockFileStorage.Object);

        }
        [TestMethod]
        public async Task PutAsync_ReturnsOkObject_ModelContainsNewPhoto()
        {
            // Arrange
            ProductFood productFood = new() { Amount = 2, Food=new() { Photo = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8z8DAwMDAxMDAwMDAAAANHQEDasKb6QAAAABJRU5ErkJggg==" } };
            var photoBase64 = Convert.FromBase64String(productFood.Food.Photo!);
            var photoInStorage = "https://orderssebas20241.blob.core.windows.net/ProductFoods/testPhoto.jpg";
            ProductFood productFoodUpdate = new ProductFood {Amount=2, Food=new() { Photo = photoInStorage } };
            var actionResponse = new ActionResponse<ProductFood> { WasSuccess = true, Result = productFoodUpdate };
            _mockFileStorage.Setup(x => x.SaveFileAsync(photoBase64, ".jpg", _container)).ReturnsAsync(photoInStorage);
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(It.Is<ProductFood>(f => f.Food!.Photo == photoInStorage)))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(productFood);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(productFoodUpdate, okResult!.Value);
            _mockFileStorage.Verify(x => x.SaveFileAsync(photoBase64, ".jpg", _container), Times.Once());
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(It.Is<ProductFood>(f => f.Food!.Photo == photoInStorage)), Times.Once());
        }
        
        [TestMethod]
        public async Task PutAsync_ReturnsOkObject_ModelContainsOldPhoto()
        {
            // Arrange
            ProductFood productFood = new() { Amount = 2, Food = new() { Photo = "https://orderssebas20241.blob.core.windows.net/foods/testPhoto.jpg" } };
            var actionResponse = new ActionResponse<ProductFood> { WasSuccess = true, Result = productFood };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(productFood))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(productFood);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(productFood, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(productFood), Times.Once());

        }
        
        [TestMethod]
        public async Task PutAsync_ReturnsOkObject_ModelNoPhoto()
        {
            // Arrange
            ProductFood productFood = new() { Amount=3 };
            var actionResponse = new ActionResponse<ProductFood> { WasSuccess = true, Result = productFood };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(productFood))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(productFood);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(productFood, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(productFood), Times.Once());
        }
        
        [TestMethod]
        public async Task PutAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        {
            // Arrange
            ProductFood productFood = new() { Amount = 3 };
            var actionResponse = new ActionResponse<ProductFood> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(productFood))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(productFood);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(productFood), Times.Once());
        }
        
        [TestMethod]
        public async Task PostAsync_ReturnsOkObject_ModelContainsPhoto()
        {
            // Arrange
            ProductFood productFood = new() { Amount = 2, Food=new() { Photo = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8z8DAwMDAxMDAwMDAAAANHQEDasKb6QAAAABJRU5ErkJggg==" } };
            var photoBase64 = Convert.FromBase64String(productFood.Food.Photo!);
            var photoInStorage = "https://orderssebas20241.blob.core.windows.net/foods/testPhoto.jpg";
            ProductFood ProductFoodUpdate = new ProductFood { Amount = 2, Food = new() { Photo = photoInStorage } };
            var actionResponse = new ActionResponse<ProductFood> { WasSuccess = true, Result = ProductFoodUpdate };
            _mockFileStorage.Setup(x => x.SaveFileAsync(photoBase64, ".jpg", _container)).ReturnsAsync(photoInStorage);
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(It.Is<ProductFood>(f => f.Food!.Photo == photoInStorage)))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(productFood);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(ProductFoodUpdate, okResult!.Value);
            _mockFileStorage.Verify(x => x.SaveFileAsync(photoBase64, ".jpg", _container), Times.Once());
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(It.Is<ProductFood>(f => f.Food!.Photo == photoInStorage)), Times.Once());
        }
        
        [TestMethod]
        public async Task PostAsync_ReturnsOkObject_ModelNoContainsPhoto()
        {
            // Arrange
            ProductFood productFood = new() { Amount=3 };
            var actionResponse = new ActionResponse<ProductFood> { WasSuccess = true, Result = productFood };
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(productFood))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(productFood);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(productFood, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(productFood), Times.Once());
        }
        
        [TestMethod]
        public async Task PostAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        {
            // Arrange
            ProductFood productFood = new() { Amount = 3 };
            var actionResponse = new ActionResponse<ProductFood> { WasSuccess = false};
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(productFood))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(productFood);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(productFood), Times.Once());
        }

        [TestMethod]
        public async Task GetAsyncById_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new ProductFood() { Amount = 3 };
            var actionResponse = new ActionResponse<ProductFood> { WasSuccess = true, Result = data };
            _mockProductFoodsUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockProductFoodsUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncById_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new ProductFood() { Amount = 3 };
            var actionResponse = new ActionResponse<ProductFood> { WasSuccess = false };
            _mockProductFoodsUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockProductFoodsUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }


    }

}
