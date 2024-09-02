using FluentValidation;

namespace Catansy.API.Models.Requests.Auth.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(r => r)
            .NotNull();

        RuleFor(r => r.Mail)
            .NotEmpty()
            .NotNull()
            .EmailAddress();

        RuleFor(r => r.Password)
            .NotEmpty();
    }
}