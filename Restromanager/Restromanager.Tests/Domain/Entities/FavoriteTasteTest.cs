using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restromanager.Backend.Domain.Entities;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class FavoriteTasteTest
    {
        [TestMethod]
        public void FavoriteTaste_Id_GetSet()
        {
            // Arrange
            var favoriteTaste = new FavoriteTaste();
            var expected = 1;

            // Act
            favoriteTaste.Id = expected;
            var actual = favoriteTaste.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FavoriteTaste_UserID_GetSet()
        {
            // Arrange
            var favoriteTaste = new FavoriteTaste();
            var expected = "user123";

            // Act
            favoriteTaste.UserID = expected;
            var actual = favoriteTaste.UserID;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FavoriteTaste_User_GetSet()
        {
            // Arrange
            var favoriteTaste = new FavoriteTaste();
            var expected = new User { Id = "user123", UserName = "sampleuser" };

            // Act
            favoriteTaste.User = expected;
            var actual = favoriteTaste.User;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FavoriteTaste_ProductID_GetSet()
        {
            // Arrange
            var favoriteTaste = new FavoriteTaste();
            var expected = 2;

            // Act
            favoriteTaste.ProductID = expected;
            var actual = favoriteTaste.ProductID;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FavoriteTaste_Product_GetSet()
        {
            // Arrange
            var favoriteTaste = new FavoriteTaste();
            var expected = new Product { Id = 2, Name = "Sample Product" };

            // Act
            favoriteTaste.Product = expected;
            var actual = favoriteTaste.Product;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
