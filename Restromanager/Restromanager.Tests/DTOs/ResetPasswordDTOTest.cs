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
    public class ResetPasswordDTOTest
    {
        [TestMethod]
        public void ResetPasswordDTO_Email_GetSet()
        {
            // Arrange
            var dto = new ResetPasswordDTO();
            var expected = "test@example.com";

            // Act
            dto.Email = expected;
            var actual = dto.Email;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ResetPasswordDTO_Password_GetSet()
        {
            // Arrange
            var dto = new ResetPasswordDTO();
            var expected = "SecurePassword123";

            // Act
            dto.Password = expected;
            var actual = dto.Password;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ResetPasswordDTO_ConfirmPassword_GetSet()
        {
            // Arrange
            var dto = new ResetPasswordDTO();
            var expected = "SecurePassword123";

            // Act
            dto.ConfirmPassword = expected;
            var actual = dto.ConfirmPassword;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ResetPasswordDTO_Token_GetSet()
        {
            // Arrange
            var dto = new ResetPasswordDTO();
            var expected = "SampleToken123";

            // Act
            dto.Token = expected;
            var actual = dto.Token;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
