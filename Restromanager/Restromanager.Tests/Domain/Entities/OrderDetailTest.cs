using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restromanager.Backend.Domain.Entities;
using System;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class OrderDetailTest
    {
        [TestMethod]
        public void OrderDetail_Id_GetSet()
        {
            // Arrange
            var orderDetail = new OrderDetail();
            var expected = 1;

            // Act
            orderDetail.Id = expected;
            var actual = orderDetail.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderDetail_Order_GetSet()
        {
            // Arrange
            var orderDetail = new OrderDetail();
            var expected = new Order { Id = 1, Date = DateTime.Now };

            // Act
            orderDetail.Order = expected;
            var actual = orderDetail.Order;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderDetail_OrderId_GetSet()
        {
            // Arrange
            var orderDetail = new OrderDetail();
            var expected = 1;

            // Act
            orderDetail.OrderId = expected;
            var actual = orderDetail.OrderId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderDetail_Product_GetSet()
        {
            // Arrange
            var orderDetail = new OrderDetail();
            var expected = new Product { Id = 1, Name = "Sample Product" };

            // Act
            orderDetail.Product = expected;
            var actual = orderDetail.Product;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderDetail_ProductId_GetSet()
        {
            // Arrange
            var orderDetail = new OrderDetail();
            var expected = 1;

            // Act
            orderDetail.ProductId = expected;
            var actual = orderDetail.ProductId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderDetail_Quantity_GetSet()
        {
            // Arrange
            var orderDetail = new OrderDetail();
            var expected = 2.5f;

            // Act
            orderDetail.Quantity = expected;
            var actual = orderDetail.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OrderDetail_Value_GetSet()
        {
            // Arrange
            var orderDetail = new OrderDetail();
            var expected = 99.99m;

            // Act
            orderDetail.Value = expected;
            var actual = orderDetail.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
