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
    public class UserDTOTest
    {
        [TestMethod]
        public void UserDTO_Password_GetSet()
        {
            // Arrange
            var dto = new UserDTO();
            var expected = "SecurePassword123";

            // Act
            dto.Password = expected;
            var actual = dto.Password;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserDTO_PasswordConfirm_GetSet()
        {
            // Arrange
            var dto = new UserDTO();
            var expected = "SecurePassword123";

            // Act
            dto.PasswordConfirm = expected;
            var actual = dto.PasswordConfirm;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
