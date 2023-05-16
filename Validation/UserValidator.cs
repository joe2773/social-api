using FluentValidation;
using Data.Entities;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Name).NotEmpty().WithMessage("Name is required.");
         RuleFor(u => u.Name).MaximumLength(25).WithMessage("Name cannot exceed 25 characters.");
        RuleFor(u => u.Bio).MaximumLength(200).WithMessage("Bio cannot exceed 200 characters.");
        RuleFor(u => u.Password).NotEmpty().MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}
