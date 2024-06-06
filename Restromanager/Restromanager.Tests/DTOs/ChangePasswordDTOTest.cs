using Restromanager.Backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.DTOs
{
    [TestClass]
    public class ChangePasswordDTOTest
    {
        [TestMethod]
        public void ChangePasswordDTO_CurrentPassword_GetSet()
        {
            // Arrange
            var dto = new ChangePasswordDTO();
            var expected = "CurrentPassword123";

            // Act
            dto.CurrentPassword = expected;
            var actual = dto.CurrentPassword;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangePasswordDTO_NewPassword_GetSet()
        {
            // Arrange
            var dto = new ChangePasswordDTO();
            var expected = "NewPassword123";

            // Act
            dto.NewPassword = expected;
            var actual = dto.NewPassword;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangePasswordDTO_Confirm_GetSet()
        {
            // Arrange
            var dto = new ChangePasswordDTO();
            var expected = "ConfirmPassword123";

            // Act
            dto.Confirm = expected;
            var actual = dto.Confirm;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
