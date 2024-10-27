using FluentValidation;
using ReviewIt.Application.Features.User.Contracts.Requests;

namespace ReviewIt.Application.Features.User.Validators;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("email")
            .NotNull().WithMessage("email");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("name")
            .NotNull().WithMessage("name");
    }
}
