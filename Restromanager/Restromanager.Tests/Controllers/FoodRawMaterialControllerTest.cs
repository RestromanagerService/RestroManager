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
    public class FoodRawMaterialControllerTest
    {
        private Mock<IGenericUnitOfWork<FoodRawMaterial>> _mockGenericUnitOfWork = null!;
        private Mock<IFoodRawMaterialsUnitOfWork> _mockFoodRawMaterialsUnitOfWork = null!;
        private Mock<IFileStorage> _mockFileStorage= null!;
        private FoodRawMaterialController _controller = null!;
        private readonly string _container = "rawMaterials";
        [TestInitialize]
        public void Setup()
        {
            _mockFoodRawMaterialsUnitOfWork = new Mock<IFoodRawMaterialsUnitOfWork>();
            _mockGenericUnitOfWork = new Mock<IGenericUnitOfWork<FoodRawMaterial>>();
            _mockFileStorage = new Mock<IFileStorage>();
            _controller = new FoodRawMaterialController(_mockGenericUnitOfWork.Object, _mockFoodRawMaterialsUnitOfWork.Object, _mockFileStorage.Object);

        }
        [TestMethod]
        public async Task PutAsync_ReturnsOkObject_ModelContainsNewPhoto()
        {
            // Arrange
            FoodRawMaterial foodRawMaterial = new() { Amount = 2, RawMaterial = new() { Photo = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8z8DAwMDAxMDAwMDAAAANHQEDasKb6QAAAABJRU5ErkJggg==" } };
            var photoBase64 = Convert.FromBase64String(foodRawMaterial.RawMaterial.Photo!);
            var photoInStorage = "https://orderssebas20241.blob.core.windows.net/rawMaterials/testPhoto.jpg";
            FoodRawMaterial FoodRawMaterialUpdate = new FoodRawMaterial {Amount=2, RawMaterial=new() { Photo = photoInStorage } };
            var actionResponse = new ActionResponse<FoodRawMaterial> { WasSuccess = true, Result = FoodRawMaterialUpdate };
            _mockFileStorage.Setup(x => x.SaveFileAsync(photoBase64, ".jpg", _container)).ReturnsAsync(photoInStorage);
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(It.Is<FoodRawMaterial>(f => f.RawMaterial!.Photo == photoInStorage)))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(foodRawMaterial);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(FoodRawMaterialUpdate, okResult!.Value);
            _mockFileStorage.Verify(x => x.SaveFileAsync(photoBase64, ".jpg", _container), Times.Once());
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(It.Is<FoodRawMaterial>(f => f.RawMaterial!.Photo == photoInStorage)), Times.Once());
        }
        
        [TestMethod]
        public async Task PutAsync_ReturnsOkObject_ModelContainsOldPhoto()
        {
            // Arrange
            FoodRawMaterial foodRawMaterial = new() { Amount = 2, RawMaterial = new() { Photo = "https://orderssebas20241.blob.core.windows.net/rawMaterials/testPhoto.jpg" } };
            var actionResponse = new ActionResponse<FoodRawMaterial> { WasSuccess = true, Result = foodRawMaterial };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(foodRawMaterial))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(foodRawMaterial);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(foodRawMaterial, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(foodRawMaterial), Times.Once());

        }
        
        [TestMethod]
        public async Task PutAsync_ReturnsOkObject_ModelNoPhoto()
        {
            // Arrange
            FoodRawMaterial FoodRawMaterial = new() { Amount=3 };
            var actionResponse = new ActionResponse<FoodRawMaterial> { WasSuccess = true, Result = FoodRawMaterial };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(FoodRawMaterial))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(FoodRawMaterial);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(FoodRawMaterial, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(FoodRawMaterial), Times.Once());
        }
        
        [TestMethod]
        public async Task PutAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        {
            // Arrange
            FoodRawMaterial FoodRawMaterial = new() { Amount = 3 };
            var actionResponse = new ActionResponse<FoodRawMaterial> { WasSuccess = false };
            _mockGenericUnitOfWork.Setup(x => x.UpdateAsync(FoodRawMaterial))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PutAsync(FoodRawMaterial);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockGenericUnitOfWork.Verify(x => x.UpdateAsync(FoodRawMaterial), Times.Once());
        }
        
        [TestMethod]
        public async Task PostAsync_ReturnsOkObject_ModelContainsPhoto()
        {
            // Arrange
            FoodRawMaterial foodRawMaterial = new() { Amount = 2, RawMaterial =new() { Photo = "iVBORw0KGgoAAAANSUhEUgAAAAIAAAACCAIAAAD91JpzAAAAFklEQVR4nGP8z8DAwMDAxMDAwMDAAAANHQEDasKb6QAAAABJRU5ErkJggg==" } };
            var photoBase64 = Convert.FromBase64String(foodRawMaterial.RawMaterial.Photo!);
            var photoInStorage = "https://orderssebas20241.blob.core.windows.net/rawMaterials/testPhoto.jpg";
            FoodRawMaterial FoodRawMaterialUpdate = new FoodRawMaterial { Amount = 2, RawMaterial = new() { Photo = photoInStorage } };
            var actionResponse = new ActionResponse<FoodRawMaterial> { WasSuccess = true, Result = FoodRawMaterialUpdate };
            _mockFileStorage.Setup(x => x.SaveFileAsync(photoBase64, ".jpg", _container)).ReturnsAsync(photoInStorage);
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(It.Is<FoodRawMaterial>(f => f.RawMaterial!.Photo == photoInStorage)))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(foodRawMaterial);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(FoodRawMaterialUpdate, okResult!.Value);
            _mockFileStorage.Verify(x => x.SaveFileAsync(photoBase64, ".jpg", _container), Times.Once());
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(It.Is<FoodRawMaterial>(f => f.RawMaterial!.Photo == photoInStorage)), Times.Once());
        }
        
        [TestMethod]
        public async Task PostAsync_ReturnsOkObject_ModelNoContainsPhoto()
        {
            // Arrange
            FoodRawMaterial foodRawMaterial = new() { Amount=3 };
            var actionResponse = new ActionResponse<FoodRawMaterial> { WasSuccess = true, Result = foodRawMaterial };
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(foodRawMaterial))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(foodRawMaterial);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(foodRawMaterial, okResult!.Value);
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(foodRawMaterial), Times.Once());
        }
        
        [TestMethod]
        public async Task PostAsync_ReturnsBadRequest_WhenWasSuccessIsFalse()
        {
            // Arrange
            FoodRawMaterial FoodRawMaterial = new() { Amount = 3 };
            var actionResponse = new ActionResponse<FoodRawMaterial> { WasSuccess = false};
            _mockGenericUnitOfWork.Setup(x => x.AddAsync(FoodRawMaterial))
                          .ReturnsAsync(actionResponse);
            // Act
            var result = await _controller.PostAsync(FoodRawMaterial);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            _mockGenericUnitOfWork.Verify(x => x.AddAsync(FoodRawMaterial), Times.Once());
        }

        [TestMethod]
        public async Task GetAsyncById_ReturnsOkObjectResult_WhenWasSuccessIsTrue()
        {
            // Arrange
            var data = new FoodRawMaterial() { Amount = 3 };
            var actionResponse = new ActionResponse<FoodRawMaterial> { WasSuccess = true, Result = data };
            _mockFoodRawMaterialsUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.AreEqual(actionResponse.Result, okResult!.Value);
            _mockFoodRawMaterialsUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }
        [TestMethod]
        public async Task GetAsyncById_ReturnsBadRequestResult_WhenWasSuccessIsFalse()
        {
            // Arrange
            var data = new FoodRawMaterial() { Amount = 3 };
            var actionResponse = new ActionResponse<FoodRawMaterial> { WasSuccess = false };
            _mockFoodRawMaterialsUnitOfWork.Setup(x => x.GetAsync(2)).ReturnsAsync(actionResponse);

            // Act
            var result = await _controller.GetAsync(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
            _mockFoodRawMaterialsUnitOfWork.Verify(x => x.GetAsync(2), Times.Once());
        }


    }

}
