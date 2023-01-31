using Sat.Recruitment.Core.Entities;

namespace Sat.Recruitment.Core.Abstractions
{
    public interface IUserValidations
    {
        void ValidateUser(User user);
    }
}
