using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Dto;

namespace Sat.Recruitment.Application.Mapping
{
    public interface IMapper
    {
        UserDto Map(User user);
        User Map(UserDto user);
    }
}
