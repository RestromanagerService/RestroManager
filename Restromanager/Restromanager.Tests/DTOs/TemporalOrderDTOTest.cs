using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restromanager.Backend.DTOs;

namespace Restromanager.Tests.DTOs
{
    [TestClass]
    public class TemporalOrderDTOTests
    {
        [TestMethod]
        public void TemporalOrderDTO_CanSetAndGetProperties()
        {
            // Arrange
            var temporalOrderDTO = new TemporalOrderDTO
            {
                ProductId = 1,
                TableId = 5,
                Quantity = 2.5f
            };

            // Act
            var productId = temporalOrderDTO.ProductId;
            var tableId = temporalOrderDTO.TableId;
            var quantity = temporalOrderDTO.Quantity;

            // Assert
            Assert.AreEqual(1, productId);
            Assert.AreEqual(5, tableId);
            Assert.AreEqual(2.5f, quantity);
        }

        [TestMethod]
        public void TemporalOrderDTO_DefaultValuesAreCorrect()
        {
            // Arrange & Act
            var temporalOrderDTO = new TemporalOrderDTO();

            // Assert
            Assert.AreEqual(0, temporalOrderDTO.ProductId);
            Assert.AreEqual(0, temporalOrderDTO.TableId);
            Assert.AreEqual(1.0f, temporalOrderDTO.Quantity);
        }

        [TestMethod]
        public void TemporalOrderDTO_CanUpdateProperties()
        {
            // Arrange
            var temporalOrderDTO = new TemporalOrderDTO
            {
                ProductId = 1,
                TableId = 5,
                Quantity = 2.5f
            };

            // Act
            temporalOrderDTO.ProductId = 3;
            temporalOrderDTO.TableId = 10;
            temporalOrderDTO.Quantity = 4.0f;

            // Assert
            Assert.AreEqual(3, temporalOrderDTO.ProductId);
            Assert.AreEqual(10, temporalOrderDTO.TableId);
            Assert.AreEqual(4.0f, temporalOrderDTO.Quantity);
        }
    }
}
