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
    public class LoginDTOTest
    {
        [TestMethod]
        public void LoginDTO_Email_GetSet()
        {
            // Arrange
            var dto = new LoginDTO();
            var expected = "test@example.com";

            // Act
            dto.Email = expected;
            var actual = dto.Email;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LoginDTO_Password_GetSet()
        {
            // Arrange
            var dto = new LoginDTO();
            var expected = "SecurePassword123";

            // Act
            dto.Password = expected;
            var actual = dto.Password;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
