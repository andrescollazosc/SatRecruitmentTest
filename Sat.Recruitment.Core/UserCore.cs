using Sat.Recruitment.Core.Abstractions;
using Sat.Recruitment.Core.Entities;

namespace Sat.Recruitment.Core
{
    public class UserCore : IUserCore
    {
        private readonly IUserValidations _userValidations;
        private readonly IBusinessRuleValidations _businessRuleValidations;

        public UserCore(IUserValidations userValidations, 
            IBusinessRuleValidations businessRuleValidations)
        {
            _userValidations = userValidations;
            _businessRuleValidations = businessRuleValidations;
        }

        public void AddUser(User user)
        {
            _userValidations.ValidateUser(user);
            _businessRuleValidations.ValidateIfUserExits(user);
        }
    }
}
