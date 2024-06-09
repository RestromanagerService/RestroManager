using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Enums;
using System.Collections.Generic;

namespace Restromanager.Tests.DTOs
{
    [TestClass]
    public class OrderDTOTests
    {
        [TestMethod]
        public void OrderDTO_CanSetAndGetProperties()
        {
            // Arrange
            var orderDetails = new List<OrderDetailDTO>
            {
                new OrderDetailDTO { ProductId = 1, Quantity = 2},
                new OrderDetailDTO { ProductId = 2, Quantity = 1}
            };

            var orderDTO = new OrderDTO
            {
                Id = 1,
                TableId = 5,
                OrderStatus = OrderStatus.New,
                OrderDetails = orderDetails
            };

            // Act
            var id = orderDTO.Id;
            var tableId = orderDTO.TableId;
            var orderStatus = orderDTO.OrderStatus;
            var orderDetailsResult = orderDTO.OrderDetails;

            // Assert
            Assert.AreEqual(1, id);
            Assert.AreEqual(5, tableId);
            Assert.AreEqual(OrderStatus.New, orderStatus);
            Assert.AreEqual(orderDetails, orderDetailsResult);
        }

        [TestMethod]
        public void OrderDTO_OrderDetails_DefaultsToEmptyList()
        {
            // Arrange & Act
            var orderDTO = new OrderDTO();

            // Assert
            Assert.IsNotNull(orderDTO.OrderDetails);
            Assert.AreEqual(0, orderDTO.OrderDetails.Count);
        }

        [TestMethod]
        public void OrderDTO_OrderDetails_CanAddOrderDetails()
        {
            // Arrange
            var orderDetail = new OrderDetailDTO { ProductId = 1, Quantity = 2};
            var orderDTO = new OrderDTO();

            // Act
            orderDTO.OrderDetails.Add(orderDetail);

            // Assert
            Assert.AreEqual(1, orderDTO.OrderDetails.Count);
            Assert.AreEqual(orderDetail, orderDTO.OrderDetails[0]);
        }
    }
}
