using Sat.Recruitment.Application.Mapping;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.Dto;
using Xunit;

namespace Sat.Recruitment.Application.Test.Mapping
{
    public class MapperTest
    {
        [Fact]
        public void Map_WhenTheParameterIsAnEntity_ReturnDto()
        {
            // Arrange
            var mapper = new Mapper();
            var user = new User
            {
                Name = "Solo Esuna Prueba",
                Email = "soloesunaprueba@gmail.com",
                Address = "Cra 5°",
                UserType = UserType.Normal,
                Money = 125,
                Phone = "32056478510"
            };

            // Act
            var userDto = mapper.Map(user);

            // Assert
            Assert.NotNull(userDto);
            Assert.Equal(userDto.Email, user.Email);
        }

        [Fact]
        public void Map_WhenTheParameterIsADto_ReturnEntity()
        {
            // Arrange
            var mapper = new Mapper();
            var userDto = new UserDto
            {
                Name = "Solo Esuna Prueba",
                Email = "soloesunaprueba@gmail.com",
                Address = "Cra 5°",
                UserType = UserType.Normal,
                Money = 125,
                Phone = "32056478510"
            };

            // Act
            var user = mapper.Map(userDto);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(user.Email, userDto.Email);
        }
    }
}
