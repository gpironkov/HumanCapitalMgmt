namespace HCMTest
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.AspNetCore.Identity;
    using Moq;
    using PeopleAPI;
    using PeopleAPI.DTOs;
    using PeopleAPI.Services;

    [TestClass]
    public class PeopleApiServicesTests
    {
        [TestMethod]
        public async Task LoginAsync_ValidUser_ReturnsTrue()
        {
            // Arrange
            var user = new LoginUserDto { UserName = "test@example.com", Password = "password123" };

            var userManagerMock = Mock.Of<UserManager<IdentityUser>>(); // Use Mock.Of to create a mock without a proxy
            var peopleDbContextMock = Mock.Of<PeopleDbContext>(); // Mock PeopleDbContext as needed
            var configMock = Mock.Of<IConfiguration>(); // Mock IConfiguration as needed

            var loginService = new Account(userManagerMock, configMock, peopleDbContextMock);

            // Configure specific methods as needed
            Mock.Get(userManagerMock)
                .Setup(x => x.FindByEmailAsync(user.UserName))
                .ReturnsAsync(new IdentityUser()); // Assume a user is found

            Mock.Get(userManagerMock)
                .Setup(x => x.CheckPasswordAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(true); // Assume password check succeeds

            // Act
            var result = await loginService.LoginAsync(user);

            // Assert
            Assert.IsTrue(result);
        }
    }
}