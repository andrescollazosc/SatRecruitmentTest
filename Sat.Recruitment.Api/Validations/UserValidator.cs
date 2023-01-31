using FluentValidation;
using Sat.Recruitment.Dto;

namespace Sat.Recruitment.Api.Validations
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The Name field is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("The Email field is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("The Address field is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("The Phone field is required.");
            RuleFor(x => x.Money).NotNull()
                .GreaterThan(10)
                .WithMessage("The Money field cannot be zero.");
        }
    }
}
