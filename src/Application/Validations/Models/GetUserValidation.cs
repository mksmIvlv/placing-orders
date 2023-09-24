using Application.MediatR.Features.Models;
using FluentValidation;

namespace Application.Validations.Models;

public class GetUserValidation : AbstractValidator<GetUserGetCommand> 
{
    public GetUserValidation()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Id).NotEmpty();
    }
}