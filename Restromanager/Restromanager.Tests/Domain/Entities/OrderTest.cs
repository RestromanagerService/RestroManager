using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void Order_Id_GetSet()
        {
            // Arrange
            var order = new Order();
            var expected = 1;

            // Act
            order.Id = expected;
            var actual = order.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_Date_GetSet()
        {
            // Arrange
            var order = new Order();
            var expected = new DateTime(2023, 6, 8, 10, 30, 0);

            // Act
            order.Date = expected;
            var actual = order.Date;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_User_GetSet()
        {
            // Arrange
            var order = new Order();
            var expected = new User { Id = "user123", UserName = "sampleuser" };

            // Act
            order.User = expected;
            var actual = order.User;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_UserId_GetSet()
        {
            // Arrange
            var order = new Order();
            var expected = "user123";

            // Act
            order.UserId = expected;
            var actual = order.UserId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_Table_GetSet()
        {
            // Arrange
            var order = new Order();
            var expected = new Table { Id = 1, Name = "Table 1" };

            // Act
            order.Table = expected;
            var actual = order.Table;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_TableId_GetSet()
        {
            // Arrange
            var order = new Order();
            var expected = 1;

            // Act
            order.TableId = expected;
            var actual = order.TableId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_OrderStatus_GetSet()
        {
            // Arrange
            var order = new Order();
            var expected = OrderStatus.Payed;

            // Act
            order.OrderStatus = expected;
            var actual = order.OrderStatus;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_OrderDetails_GetSet()
        {
            // Arrange
            var order = new Order();
            var expected = new List<OrderDetail>
            {
                new OrderDetail { Id = 1, Quantity = 2, Value = 10m },
                new OrderDetail { Id = 2, Quantity = 3, Value = 15m }
            };

            // Act
            order.OrderDetails = expected;
            var actual = order.OrderDetails;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_Quantity_Calculation()
        {
            // Arrange
            var order = new Order
            {
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail { Quantity = 2 },
                    new OrderDetail { Quantity = 3 }
                }
            };
            var expected = 5f;

            // Act
            var actual = order.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_Value_Calculation()
        {
            // Arrange
            var order = new Order
            {
                OrderDetails = new List<OrderDetail>
                {
                    new OrderDetail { Value = 10m },
                    new OrderDetail { Value = 15m }
                }
            };
            var expected = 25m;

            // Act
            var actual = order.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_Quantity_Calculation_NoOrderDetails()
        {
            // Arrange
            var order = new Order();
            var expected = 0f;

            // Act
            var actual = order.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Order_Value_Calculation_NoOrderDetails()
        {
            // Arrange
            var order = new Order();
            var expected = 0m;

            // Act
            var actual = order.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
