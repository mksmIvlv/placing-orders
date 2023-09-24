using Application.MediatR.Features.Models;
using FluentValidation;

namespace Application.Validations.Models;

public class DeleteUserValidator : AbstractValidator<DeleteUserDeleteCommand>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Id).NotEmpty();
    }
}