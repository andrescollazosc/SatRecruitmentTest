using Sat.Recruitment.Application.Abstractions;
using Sat.Recruitment.Application.Mapping;
using Sat.Recruitment.Core.Abstractions;
using Sat.Recruitment.Dto;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserCore _user;
        private readonly IMapper _mapper;

        public UserApplication(IUserCore user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task AddUser(UserDto user)
        {
            var domainObject = _mapper.Map(user);

            _user.AddUser(domainObject);
        }
    }
}
