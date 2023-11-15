using Application.MediatR.Features.Models;
using FluentValidation;

namespace Application.Validations.Models;

public class EditUserValidation : AbstractValidator<EditUserCommand>
{
    public EditUserValidation()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).Must(HelperMethods.IsValidFullName);
        RuleFor(x => x.Surname).NotNull();
        RuleFor(x => x.Surname).NotEmpty();
        RuleFor(x => x.Surname).Must(HelperMethods.IsValidFullName);
    }
}