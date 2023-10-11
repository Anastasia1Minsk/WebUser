using FluentValidation;
using WebUser.ModelsDto;

namespace WebUser.Validations
{
    public class NewRelationValidator : AbstractValidator<NewRelationDto>
    {
        public NewRelationValidator()
        {
            {
                RuleFor(x => x.UserId)
                    .NotEmpty()
                    .WithMessage("Required field")
                    .GreaterThan(-1)
                    .WithMessage("Impossible"); ;
                RuleFor(x => x.RoleId)
                    .NotEmpty()
                    .WithMessage("Required field")
                    .GreaterThan(-1)
                    .WithMessage("Impossible"); ;
            }
        }
    }
}
