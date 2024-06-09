using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Repositories.Interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.implementations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restrommanager.Tests.UnitsOfWork
{
    [TestClass]
    public class CitiesUnitOfWorkTests
    {
        private Mock<IGenericRepository<City>> _mockGenericRepository;
        private Mock<ICitiesRepository> _mockCitiesRepository;
        private CitiesUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<City>>();
            _mockCitiesRepository = new Mock<ICitiesRepository>();
            _unitOfWork = new CitiesUnitOfWork(_mockGenericRepository.Object, _mockCitiesRepository.Object);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsFilteredAndPaginatedCities()
        {
            // Arrange
            var pagination = new PaginationDTO { Filter = "City", Page = 1, RecordsNumber = 2 };
            var cities = new List<City>
            {
                new City { Id = 1, Name = "City 1" },
                new City { Id = 2, Name = "City 2" }
            };
            var response = new ActionResponse<IEnumerable<City>> { WasSuccess = true, Result = cities };

            _mockCitiesRepository.Setup(r => r.GetAsync(pagination)).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetAsync(pagination);

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(2, result.Result.Count());
        }

        [TestMethod]
        public async Task GetComboAsync_ReturnsOrderedCities()
        {
            // Arrange
            var stateId = 1;
            var cities = new List<City>
            {
                new City { Id = 1, Name = "A City" },
                new City { Id = 2, Name = "B City" }
            };
            var response = new ActionResponse<IEnumerable<City>> { WasSuccess = true, Result = cities };

            _mockCitiesRepository.Setup(r => r.GetComboAsync(stateId)).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetComboAsync(stateId);

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(2, result.Result.Count());
            Assert.AreEqual("A City", result.Result.First().Name);
        }

        [TestMethod]
        public async Task GetTotalPagesAsync_ReturnsTotalPages()
        {
            // Arrange
            var pagination = new PaginationDTO { Filter = "City", Page = 1, RecordsNumber = 2 };
            var response = new ActionResponse<int> { WasSuccess = true, Result = 1 };

            _mockCitiesRepository.Setup(r => r.GetTotalPagesAsync(pagination)).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetTotalPagesAsync(pagination);

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(1, result.Result);
        }
    }
}
