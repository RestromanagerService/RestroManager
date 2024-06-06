using Restromanager.Backend.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.DTOs
{

    [TestClass]
    public class PaginationDTOTest
    {
        [TestMethod]
        public void PaginationDTO_Id_GetSet()
        {
            // Arrange
            var dto = new PaginationDTO();
            var expected = 123;

            // Act
            dto.Id = expected;
            var actual = dto.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PaginationDTO_Page_GetSet()
        {
            // Arrange
            var dto = new PaginationDTO();
            var expected = 5;

            // Act
            dto.Page = expected;
            var actual = dto.Page;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PaginationDTO_RecordsNumber_GetSet()
        {
            // Arrange
            var dto = new PaginationDTO();
            var expected = 50;

            // Act
            dto.RecordsNumber = expected;
            var actual = dto.RecordsNumber;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PaginationDTO_Filter_GetSet()
        {
            // Arrange
            var dto = new PaginationDTO();
            var expected = "test filter";

            // Act
            dto.Filter = expected;
            var actual = dto.Filter;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PaginationDTO_DefaultValues()
        {
            // Arrange
            var dto = new PaginationDTO();

            // Act
            var defaultPage = dto.Page;
            var defaultRecordsNumber = dto.RecordsNumber;

            // Assert
            Assert.AreEqual(1, defaultPage);
            Assert.AreEqual(10, defaultRecordsNumber);
        }
    }
}
