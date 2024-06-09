using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.implementations;
using System.Threading.Tasks;

namespace Restrommanager.Tests.UnitsOfWork
{
    [TestClass]
    public class FoodRawMaterialsUnitOfWorkTests
    {
        private Mock<IGenericRepository<FoodRawMaterial>> _mockGenericRepository;
        private Mock<IFoodRawMaterialsRepository> _mockFoodRawMaterialsRepository;
        private FoodRawMateriaslsUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<FoodRawMaterial>>();
            _mockFoodRawMaterialsRepository = new Mock<IFoodRawMaterialsRepository>();
            _unitOfWork = new FoodRawMateriaslsUnitOfWork(_mockGenericRepository.Object, _mockFoodRawMaterialsRepository.Object);
        }

        [TestMethod]
        public async Task GetAsync_ById_ReturnsFoodRawMaterial()
        {
            // Arrange
            var foodRawMaterial = new FoodRawMaterial { Id = 1, Amount = 100 };
            var response = new ActionResponse<FoodRawMaterial> { WasSuccess = true, Result = foodRawMaterial };

            _mockFoodRawMaterialsRepository.Setup(r => r.GetAsync(1)).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetAsync(1);

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(foodRawMaterial, result.Result);
        }
    }
}
