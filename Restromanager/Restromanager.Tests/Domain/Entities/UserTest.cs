using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.Domain.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void User_Id_GetSet()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = "user123";

            // Act
            user.Id = expected;
            var actual = user.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void User_Document_GetSet()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = "654321";

            // Act
            user.Document = expected;
            var actual = user.Document;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void User_FirstName_GetSet()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = "Jane";

            // Act
            user.FirstName = expected;
            var actual = user.FirstName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void User_LastName_GetSet()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = "Smith";

            // Act
            user.LastName = expected;
            var actual = user.LastName;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void User_Address_GetSet()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = "456 Avenue";

            // Act
            user.Address = expected;
            var actual = user.Address;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void User_Photo_GetSet()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = "photo.jpg";

            // Act
            user.Photo = expected;
            var actual = user.Photo;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void User_UserType_GetSet()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = UserType.User;

            // Act
            user.UserType = expected;
            var actual = user.UserType;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void User_CityId_GetSet()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = 2;

            // Act
            user.CityId = expected;
            var actual = user.CityId;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void User_City_GetSet()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = new City { Id = 1, Name = "Sample City" };

            // Act
            user.City = expected;
            var actual = user.City;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void User_FullName_Get()
        {
            // Arrange
            var user = new User
            {
                Document = "123456",
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Street",
                UserType = UserType.Admin,
                CityId = 1
            };
            var expected = "John Doe";

            // Act
            var actual = user.FullName;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
