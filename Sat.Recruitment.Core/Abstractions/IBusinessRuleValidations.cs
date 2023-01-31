using Sat.Recruitment.Core.Entities;

namespace Sat.Recruitment.Core.Abstractions
{
    public interface IBusinessRuleValidations
    {
        void ValidateIfUserExits(User entity);
    }
}
