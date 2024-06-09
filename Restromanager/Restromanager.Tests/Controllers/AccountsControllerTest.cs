using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Restromanager.Backend.Controllers;
using Restromanager.Backend.Domain.Entities;
using Restromanager.Backend.DTOs;
using Restromanager.Backend.Helpers;
using Restromanager.Backend.Responses;
using Restromanager.Backend.UnitsOfWork.interfaces;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace Restromanager.Tests.Controllers
{
    [TestClass]
    public class AccountsControllerTests
    {
        private Mock<IUserUnitOfWork> _mockUserUnitOfWork;
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<IFileStorage> _mockFileStorage;
        private Mock<IMailHelper> _mockMailHelper;
        private AccountsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockUserUnitOfWork = new Mock<IUserUnitOfWork>();
            _mockConfiguration = new Mock<IConfiguration>();
            _mockFileStorage = new Mock<IFileStorage>();
            _mockMailHelper = new Mock<IMailHelper>();

            _controller = new AccountsController(
                _mockUserUnitOfWork.Object,
                _mockConfiguration.Object,
                _mockFileStorage.Object,
                _mockMailHelper.Object
            );

            // Configurar el contexto del usuario
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, "test@example.com")
            }, "mock"));

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }

        [TestMethod]
        public async Task CreateUserAsync_ReturnsNoContent_WhenSuccess()
        {
            // Arrange
            var userDto = new UserDTO { Email = "test@example.com", Password = "Test123!", Photo = null };
            _mockUserUnitOfWork.Setup(u => u.AddUserAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _mockUserUnitOfWork.Setup(u => u.AddUserToRoleAsync(It.IsAny<User>(), It.IsAny<string>())).Returns(Task.CompletedTask);
            _mockMailHelper.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ActionResponse<string> { WasSuccess = true });

            // Act
            var result = await _controller.CreateUserAsync(userDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task CreateUserAsync_ReturnsBadRequest_WhenAddUserFails()
        {
            // Arrange
            var userDto = new UserDTO { Email = "test@example.com", Password = "Test123!", Photo = null };
            _mockUserUnitOfWork.Setup(u => u.AddUserAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error" }));

            // Act
            var result = await _controller.CreateUserAsync(userDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task ConfirmEmailAsync_ReturnsNoContent_WhenSuccess()
        {
            // Arrange
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(It.IsAny<Guid>())).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.ConfirmEmailAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.ConfirmEmailAsync(user.Id.ToString(), "valid_token");

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task ConfirmEmailAsync_ReturnsBadRequest_WhenConfirmEmailFails()
        {
            // Arrange
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(It.IsAny<Guid>())).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.ConfirmEmailAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error" }));

            // Act
            var result = await _controller.ConfirmEmailAsync(user.Id.ToString(), "invalid_token");

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task ResendTokenAsync_ReturnsNoContent_WhenSuccess()
        {
            // Arrange
            var emailDto = new EmailDTO { Email = "test@example.com" };
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(emailDto.Email)).ReturnsAsync(user);
            _mockMailHelper.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ActionResponse<string> { WasSuccess = true });

            // Act
            var result = await _controller.ResedTokenAsync(emailDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task ResendTokenAsync_ReturnsBadRequest_WhenSendMailFails()
        {
            // Arrange
            var emailDto = new EmailDTO { Email = "test@example.com" };
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(emailDto.Email)).ReturnsAsync(user);
            _mockMailHelper.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ActionResponse<string> { WasSuccess = false, Message = "Error" });

            // Act
            var result = await _controller.ResedTokenAsync(emailDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task ResendTokenAsync_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange
            var emailDto = new EmailDTO { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(emailDto.Email)).ReturnsAsync((User)null);

            // Act
            var result = await _controller.ResedTokenAsync(emailDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task RecoverPasswordAsync_ReturnsNoContent_WhenSuccess()
        {
            // Arrange
            var emailDto = new EmailDTO { Email = "test@example.com" };
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(emailDto.Email)).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.GeneratePasswordResetTokenAsync(user)).ReturnsAsync("reset_token");
            _mockMailHelper.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ActionResponse<string> { WasSuccess = true });

            // Act
            var result = await _controller.RecoverPasswordAsync(emailDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task RecoverPasswordAsync_ReturnsBadRequest_WhenSendMailFails()
        {
            // Arrange
            var emailDto = new EmailDTO { Email = "test@example.com" };
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(emailDto.Email)).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.GeneratePasswordResetTokenAsync(user)).ReturnsAsync("reset_token");
            _mockMailHelper.Setup(m => m.SendMail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new ActionResponse<string> { WasSuccess = false, Message = "Error" });

            // Act
            var result = await _controller.RecoverPasswordAsync(emailDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task RecoverPasswordAsync_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange
            var emailDto = new EmailDTO { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(emailDto.Email)).ReturnsAsync((User)null);

            // Act
            var result = await _controller.RecoverPasswordAsync(emailDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task ResetPasswordAsync_ReturnsNoContent_WhenSuccess()
        {
            // Arrange
            var resetPasswordDto = new ResetPasswordDTO { Email = "test@example.com", Token = "valid_token", Password = "NewPassword123!" };
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(resetPasswordDto.Email)).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.ResetPasswordAsync(resetPasswordDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task ResetPasswordAsync_ReturnsBadRequest_WhenResetPasswordFails()
        {
            // Arrange
            var resetPasswordDto = new ResetPasswordDTO { Email = "test@example.com", Token = "invalid_token", Password = "NewPassword123!" };
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(resetPasswordDto.Email)).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password)).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error" }));

            // Act
            var result = await _controller.ResetPasswordAsync(resetPasswordDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task ResetPasswordAsync_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange
            var resetPasswordDto = new ResetPasswordDTO { Email = "test@example.com", Token = "invalid_token", Password = "NewPassword123!" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(resetPasswordDto.Email)).ReturnsAsync((User)null);

            // Act
            var result = await _controller.ResetPasswordAsync(resetPasswordDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task ChangePasswordAsync_ReturnsNoContent_WhenSuccess()
        {
            // Arrange
            var changePasswordDto = new ChangePasswordDTO { CurrentPassword = "OldPassword123!", NewPassword = "NewPassword123!" };
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(It.IsAny<string>())).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword)).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.ChangePasswordAsync(changePasswordDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task ChangePasswordAsync_ReturnsBadRequest_WhenChangePasswordFails()
        {
            // Arrange
            var changePasswordDto = new ChangePasswordDTO { CurrentPassword = "OldPassword123!", NewPassword = "NewPassword123!" };
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(It.IsAny<string>())).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword)).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error" }));

            // Act
            var result = await _controller.ChangePasswordAsync(changePasswordDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task ChangePasswordAsync_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange
            var changePasswordDto = new ChangePasswordDTO { CurrentPassword = "OldPassword123!", NewPassword = "NewPassword123!" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(It.IsAny<string>())).ReturnsAsync((User)null);

            // Act
            var result = await _controller.ChangePasswordAsync(changePasswordDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task PutAsync_ReturnsOk_WhenSuccess()
        {
            // Arrange
            var user = new User { Email = "test@example.com", FirstName = "John", LastName = "Doe" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(It.IsAny<string>())).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.UpdateUserAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.PutAsync(user);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task PutAsync_ReturnsBadRequest_WhenUpdateUserFails()
        {
            // Arrange
            var user = new User { Email = "test@example.com", FirstName = "John", LastName = "Doe" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(It.IsAny<string>())).ReturnsAsync(user);
            _mockUserUnitOfWork.Setup(u => u.UpdateUserAsync(It.IsAny<User>())).ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Error" }));

            // Act
            var result = await _controller.PutAsync(user);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task GetAsync_ReturnsOk_WhenSuccess()
        {
            // Arrange
            var user = new User { Email = "test@example.com" };
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetAsync_ReturnsNotFound_WhenUserNotFound()
        {
            // Arrange
            _mockUserUnitOfWork.Setup(u => u.GetUserAsync(It.IsAny<string>())).ReturnsAsync((User)null);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
