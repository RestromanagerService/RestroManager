using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restromanager.Backend.DTOs;

namespace Restromanager.Tests.DTOs
{
    [TestClass]
    public class OrderDetailDTOTests
    {
        [TestMethod]
        public void OrderDetailDTO_CanSetAndGetProperties()
        {
            // Arrange
            var orderDetailDTO = new OrderDetailDTO
            {
                ProductId = 1,
                Quantity = 2
            };

            // Act
            var productId = orderDetailDTO.ProductId;
            var quantity = orderDetailDTO.Quantity;

            // Assert
            Assert.AreEqual(1, productId);
            Assert.AreEqual(2, quantity);
        }

        [TestMethod]
        public void OrderDetailDTO_DefaultValuesAreCorrect()
        {
            // Arrange & Act
            var orderDetailDTO = new OrderDetailDTO();

            // Assert
            Assert.AreEqual(0, orderDetailDTO.ProductId);
            Assert.AreEqual(0, orderDetailDTO.Quantity);
        }

        [TestMethod]
        public void OrderDetailDTO_CanUpdateProperties()
        {
            // Arrange
            var orderDetailDTO = new OrderDetailDTO
            {
                ProductId = 1,
                Quantity = 2
            };

            // Act
            orderDetailDTO.ProductId = 3;
            orderDetailDTO.Quantity = 5;

            // Assert
            Assert.AreEqual(3, orderDetailDTO.ProductId);
            Assert.AreEqual(5, orderDetailDTO.Quantity);
        }
    }
}
