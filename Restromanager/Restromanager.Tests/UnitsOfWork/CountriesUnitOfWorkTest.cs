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
    public class CountriesUnitOfWorkTests
    {
        private Mock<IGenericRepository<Country>> _mockGenericRepository;
        private Mock<ICountriesRepository> _mockCountriesRepository;
        private CountriesUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<Country>>();
            _mockCountriesRepository = new Mock<ICountriesRepository>();
            _unitOfWork = new CountriesUnitOfWork(_mockGenericRepository.Object, _mockCountriesRepository.Object);
        }

        [TestMethod]
        public async Task GetAsync_ById_ReturnsCountry()
        {
            // Arrange
            var country = new Country { Id = 1, Name = "Country 1" };
            var response = new ActionResponse<Country> { WasSuccess = true, Result = country };

            _mockCountriesRepository.Setup(r => r.GetAsync(1)).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetAsync(1);

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(country, result.Result);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsAllCountries()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country { Id = 1, Name = "Country 1" },
                new Country { Id = 2, Name = "Country 2" }
            };
            var response = new ActionResponse<IEnumerable<Country>> { WasSuccess = true, Result = countries };

            _mockCountriesRepository.Setup(r => r.GetAsync()).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetAsync();

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(2, result.Result.Count());
        }

        [TestMethod]
        public async Task GetAsync_WithPagination_ReturnsFilteredAndPaginatedCountries()
        {
            // Arrange
            var pagination = new PaginationDTO { Filter = "Country", Page = 1, RecordsNumber = 2 };
            var countries = new List<Country>
            {
                new Country { Id = 1, Name = "Country 1" },
                new Country { Id = 2, Name = "Country 2" }
            };
            var response = new ActionResponse<IEnumerable<Country>> { WasSuccess = true, Result = countries };

            _mockCountriesRepository.Setup(r => r.GetAsync(pagination)).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetAsync(pagination);

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(2, result.Result.Count());
        }

        [TestMethod]
        public async Task GetComboAsync_ReturnsOrderedCountries()
        {
            // Arrange
            var countries = new List<Country>
            {
                new Country { Id = 1, Name = "A Country" },
                new Country { Id = 2, Name = "B Country" }
            };
            var response = new ActionResponse<IEnumerable<Country>> { WasSuccess = true, Result = countries };

            _mockCountriesRepository.Setup(r => r.GetComboAsync()).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetComboAsync();

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(2, result.Result.Count());
            Assert.AreEqual("A Country", result.Result.First().Name);
        }

        [TestMethod]
        public async Task GetTotalPagesAsync_ReturnsTotalPages()
        {
            // Arrange
            var pagination = new PaginationDTO { Filter = "Country", Page = 1, RecordsNumber = 2 };
            var response = new ActionResponse<int> { WasSuccess = true, Result = 1 };

            _mockCountriesRepository.Setup(r => r.GetTotalPagesAsync(pagination)).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetTotalPagesAsync(pagination);

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(1, result.Result);
        }
    }
}
