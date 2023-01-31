using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Dto;

namespace Sat.Recruitment.Application.Mapping
{
    public class Mapper : IMapper
    {
        public UserDto Map(User user)
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Money = user.Money,
                Phone = user.Phone,
                UserType = user.UserType
            };
        }

        public User Map(UserDto user)
        {
            return new User
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Money = user.Money,
                Phone = user.Phone,
                UserType = user.UserType
            };
        }
    }
}
