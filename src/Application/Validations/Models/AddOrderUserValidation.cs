using Application.MediatR.Features.Models;
using FluentValidation;

namespace Application.Validations.Models;

public class AddOrderUserValidation : AbstractValidator<AddOrderUserCommand>
{
    public AddOrderUserValidation() 
    {
        RuleFor(x => x.NameOrder).NotNull();
        RuleFor(x => x.NameOrder).NotEmpty();
        RuleFor(x => x.NameOrder).Must(HelperMethods.IsValidFullName);
        RuleFor(x => x.DescriptionOrder).NotNull();
        RuleFor(x => x.DescriptionOrder).NotEmpty();
        RuleFor(x => x.Price).NotNull();
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.Price).Must(HelperMethods.IsValidPrice);
    }
}