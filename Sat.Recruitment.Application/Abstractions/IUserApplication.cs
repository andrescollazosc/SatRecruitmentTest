using System.Threading.Tasks;
using Sat.Recruitment.Dto;

namespace Sat.Recruitment.Application.Abstractions
{
    public interface IUserApplication
    {
        Task AddUser(UserDto user);
    }
}
