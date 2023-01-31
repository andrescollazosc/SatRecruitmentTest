using Moq;
using Sat.Recruitment.Application.Mapping;
using Sat.Recruitment.Core.Abstractions;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.Dto;
using Xunit;

namespace Sat.Recruitment.Application.Test
{
    public class UserApplicationTest
    {
        [Fact]
        public async void AddUser()
        {
            // Arrange
            var mapper = new Mock<IMapper>();
            var userCore = new Mock<IUserCore>();
            var userDto = new UserDto
            {
                Name = "Solo Esuna Prueba",
                Email = "soloesunaprueba@gmail.com",
                Address = "Cra 5°",
                UserType = UserType.Normal,
                Money = 125,
                Phone = "32056478510"
            };
            var userApp = new UserApplication(userCore.Object, mapper.Object);

            // Act
            // Assert
            await userApp.AddUser(userDto);
        }
    }
}
