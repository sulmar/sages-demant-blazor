using BlazorServerApp.Domain.Abstractions;
using FluentValidation;

namespace BlazorServerApp.Domain.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .Length(3, 10);

        RuleFor(c => c.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(c => c.HashedPassword)
            .NotEmpty()
            .WithMessage("Password is required.");

        RuleFor(c => c.ConfirmedPassword)
            .Equal(c => c.HashedPassword)
            .WithMessage("The password and confirmation password do not match.");

    }
}
