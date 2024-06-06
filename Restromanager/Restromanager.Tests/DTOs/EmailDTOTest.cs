using Restromanager.Backend.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restromanager.Tests.DTOs
{

    [TestClass]
    public class EmailDTOTest
    {
        [TestMethod]
        public void EmailDTO_Email_GetSet()
        {
            // Arrange
            var dto = new EmailDTO();
            var expected = "test@example.com";

            // Act
            dto.Email = expected;
            var actual = dto.Email;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
