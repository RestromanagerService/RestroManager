using Moq;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Repositories.interfaces;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.UnitsOfWork
{
    [TestClass]
    public class CategoriesUnitOfWorkTest
    {
        private Mock<IGenericRepository<Category>> _mockGenericRepository;
        private Mock<ICategoriesRepository> _mockCategoriesRepository;
        private CategoriesUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Setup()
        {
            _mockGenericRepository = new Mock<IGenericRepository<Category>>();
            _mockCategoriesRepository = new Mock<ICategoriesRepository>();
            _unitOfWork = new CategoriesUnitOfWork(_mockGenericRepository.Object, _mockCategoriesRepository.Object);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsFilteredAndPaginatedCategories()
        {
            // Arrange
            var pagination = new PaginationDTO { Filter = "Category", Page = 1, RecordsNumber = 2 };
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" }
            };
            var response = new ActionResponse<IEnumerable<Category>> { WasSuccess = true, Result = categories };

            _mockCategoriesRepository.Setup(r => r.GetAsync(pagination)).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetAsync(pagination);

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(2, result.Result.Count());
        }

        [TestMethod]
        public async Task GetComboAsync_ReturnsOrderedCategories()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "A Category" },
                new Category { Id = 2, Name = "B Category" }
            };
            var response = new ActionResponse<IEnumerable<Category>> { WasSuccess = true, Result = categories };

            _mockCategoriesRepository.Setup(r => r.GetComboAsync()).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetComboAsync();

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(2, result.Result.Count());
            Assert.AreEqual("A Category", result.Result.First().Name);
        }

        [TestMethod]
        public async Task GetTotalPagesAsync_ReturnsTotalPages()
        {
            // Arrange
            var pagination = new PaginationDTO { Filter = "Category", Page = 1, RecordsNumber = 2 };
            var response = new ActionResponse<int> { WasSuccess = true, Result = 1 };

            _mockCategoriesRepository.Setup(r => r.GetTotalPagesAsync(pagination)).ReturnsAsync(response);

            // Act
            var result = await _unitOfWork.GetTotalPagesAsync(pagination);

            // Assert
            Assert.IsTrue(result.WasSuccess);
            Assert.AreEqual(1, result.Result);
        }
    }
}
