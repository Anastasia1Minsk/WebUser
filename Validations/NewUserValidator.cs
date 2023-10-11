using FluentValidation;
using WebUser.ModelsDto;

namespace WebUser.Validations
{
    public class NewUserValidator : AbstractValidator<NewUserDto>
    {
        public NewUserValidator()
        {
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
        }
    }
}
