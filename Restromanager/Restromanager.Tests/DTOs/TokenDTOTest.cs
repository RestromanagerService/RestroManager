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
    public class TokenDTOTest
    {
        [TestMethod]
        public void TokenDTO_Token_GetSet()
        {
            // Arrange
            var dto = new TokenDTO();
            var expected = "SampleToken123";

            // Act
            dto.Token = expected;
            var actual = dto.Token;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TokenDTO_Expiration_GetSet()
        {
            // Arrange
            var dto = new TokenDTO();
            var expected = DateTime.Now.AddHours(1);

            // Act
            dto.Expiration = expected;
            var actual = dto.Expiration;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
