using FluentValidation;
using WebUser.ModelsDto;

namespace WebUser.Validations
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Required field");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Required field");
            RuleFor(x => x.Age)
                .NotEmpty()
                .WithMessage("Required field")
                .GreaterThan(-1)
                .WithMessage("Impossible");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Required field")
                .EmailAddress()
                .WithMessage("Please fill correctly");
            RuleFor(x => x.Roles)
                .NotEmpty()
                .WithMessage("Required");
        }
    }
}
