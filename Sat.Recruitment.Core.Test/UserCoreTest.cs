using Moq;
using Sat.Recruitment.Core.Abstractions;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.Core.Exceptions;
using Sat.Recruitment.Core.Validations;
using Xunit;

namespace Sat.Recruitment.Core.Test
{
    public class UserCoreTest
    {
        [Fact]
        public void AddUser_WhenTheMoneyFieldIsLessThan10_ReturnException()
        {
            // Arrange
            var userValidation = new UserValidations();
            var businessRule = new Mock<IBusinessRuleValidations>();
            var userCore = new UserCore(userValidation, businessRule.Object);
            var user = new User
            {
                Money = 8,
                UserType = UserType.Normal,
                Email = "andrestes@gmail.com",
                Address = "cra 5",
                Phone = "3154444",
                Name = "Test Andres"
            };

            // Act
            // Assert
            Assert.Throws<UserException>(() => userCore.AddUser(user));
        }

        [Theory]
        [InlineData(11, UserType.Normal)]
        [InlineData(110, UserType.Normal)]
        [InlineData(110, UserType.SuperUser)]
        [InlineData(110, UserType.Premium)]
        public void AddUser_ValidateRulesForAllUsers_ResultSuccess(decimal money, UserType userType)
        {
            // Arrange
            var userValidation = new UserValidations();
            var businessRule = new Mock<IBusinessRuleValidations>();
            var userCore = new UserCore(userValidation, businessRule.Object);
            var user = new User
            {
                Money = money,
                UserType = userType,
                Email = "andrestes@gmail.com",
                Address = "cra 5",
                Phone = "3154444",
                Name = "Test Andres"
            };

            // Act
            userCore.AddUser(user);

            // Assert
        }

        [Fact]
        public void AddUser_WhenEmailExitsInUserFile_ReturnException()
        {
            // Arrange
            var userValidation = new Mock<IUserValidations>();
            var businessRule = new BusinessRuleValidations();
            var userCore = new UserCore(userValidation.Object, businessRule);
            var user = new User
            {
                Money = 8,
                UserType = UserType.Normal,
                Email = "Franco.Perez@gmail.com",
                Address = "cra 5",
                Phone = "3154444",
                Name = "Test Andres"
            };

            // Act
            // Assert
            Assert.Throws<UserException>(() => userCore.AddUser(user));
        }

        [Fact]
        public void AddUser_WhenEmailDoesNotExitsInUserFile_ResultSuccess()
        {
            // Arrange
            var userValidation = new Mock<IUserValidations>();
            var businessRule = new BusinessRuleValidations();
            var userCore = new UserCore(userValidation.Object, businessRule);
            var user = new User
            {
                Money = 8,
                UserType = UserType.Normal,
                Email = "Franco.Perez@gmail-1.com",
                Address = "cra 5",
                Phone = "3154444",
                Name = "Test Andres"
            };

            // Act
            // Assert
            userCore.AddUser(user);
        }
    }
}
