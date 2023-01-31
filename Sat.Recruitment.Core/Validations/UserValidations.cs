using System;
using Sat.Recruitment.Core.Abstractions;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.Core.Exceptions;

namespace Sat.Recruitment.Core.Validations
{
    public class UserValidations : IUserValidations
    {
        public void ValidateUser(User user)
        {
            VlidateUserMoney(user);
            switch (user.UserType)
            {
                case UserType.Normal:
                    ValidateNormalUser(user);
                    break;
                case UserType.SuperUser:
                    ValidateSuperUser(user);
                    break;
                case UserType.Premium:
                    ValidatePremiumUser(user);
                    break;
            }
        }

        private void VlidateUserMoney(User user)
        {
            if (user.Money < 10)
                throw new UserException("The Money field cannot be less than 10.");
        }

        private void ValidateNormalUser(User user)
        {
            if (user.Money > 100)
                CalculatePercentage(user, "0.12");
            else if (user.Money > 10 && user.Money < 100)
                CalculatePercentage(user, "0.8");
        }

        private void ValidateSuperUser(User user)
        {
            if (user.Money > 100)
                CalculatePercentage(user, "0.20");
        }

        private void ValidatePremiumUser(User user)
        {
            var gif = user.Money * 2;
            user.Money = user.Money + gif;
        }

        private void CalculatePercentage(User user, string valuePercentage)
        {
            var percentage = Convert.ToDecimal(valuePercentage);
            var gif = user.Money * percentage;
            user.Money = user.Money + gif;
        }
    }
}
