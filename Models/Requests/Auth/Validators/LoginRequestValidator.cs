using FluentValidation;

namespace Catansy.API.Models.Requests.Auth.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(r => r)
            .NotNull();

        RuleFor(r => r.Mail)
            .EmailAddress();

        RuleFor(r => r.Password)
            .NotEmpty();
    }
}