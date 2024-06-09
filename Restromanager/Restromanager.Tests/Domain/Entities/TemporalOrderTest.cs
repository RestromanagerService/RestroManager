using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restromanager.Backend.Domain.Entities;
using System;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class TemporalOrderTest
    {
        [TestMethod]
        public void TemporalOrder_Id_GetSet()
        {
            // Arrange
            var temporalOrder = new TemporalOrder();
            var expected = 1;

            // Act
            temporalOrder.Id = expected;
            var actual = temporalOrder.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TemporalOrder_User_GetSet()
        {
            // Arrange
            var temporalOrder = new TemporalOrder();
            var expected = new User { Id = "user123", UserName = "sampleuser" };

            // Act
            temporalOrder.User = expected;
            var actual = temporalOrder.User;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TemporalOrder_UserId_GetSet()
        {
            // Arrange
            var temporalOrder = new TemporalOrder();
            var expected = "user123";

            // Act
            temporalOrder.UserId = expected;
            var actual = temporalOrder.UserId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TemporalOrder_Table_GetSet()
        {
            // Arrange
            var temporalOrder = new TemporalOrder();
            var expected = new Table { Id = 1, Name = "Table 1" };

            // Act
            temporalOrder.Table = expected;
            var actual = temporalOrder.Table;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TemporalOrder_TableId_GetSet()
        {
            // Arrange
            var temporalOrder = new TemporalOrder();
            var expected = 1;

            // Act
            temporalOrder.TableId = expected;
            var actual = temporalOrder.TableId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TemporalOrder_Product_GetSet()
        {
            // Arrange
            var temporalOrder = new TemporalOrder();
            var expected = new Product { Id = 1, Name = "Sample Product", Price = 10.0m };

            // Act
            temporalOrder.Product = expected;
            var actual = temporalOrder.Product;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TemporalOrder_ProductId_GetSet()
        {
            // Arrange
            var temporalOrder = new TemporalOrder();
            var expected = 1;

            // Act
            temporalOrder.ProductId = expected;
            var actual = temporalOrder.ProductId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TemporalOrder_Quantity_GetSet()
        {
            // Arrange
            var temporalOrder = new TemporalOrder();
            var expected = 2.5f;

            // Act
            temporalOrder.Quantity = expected;
            var actual = temporalOrder.Quantity;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TemporalOrder_Value_Calculation()
        {
            // Arrange
            var temporalOrder = new TemporalOrder
            {
                Product = new Product { Price = 10.0m },
                Quantity = 2.5f
            };
            var expected = 25.0m;

            // Act
            var actual = temporalOrder.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TemporalOrder_Value_Calculation_NoProduct()
        {
            // Arrange
            var temporalOrder = new TemporalOrder
            {
                Quantity = 2.5f
            };
            var expected = 0m;

            // Act
            var actual = temporalOrder.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
