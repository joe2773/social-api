using FluentValidation;
using Data.Entities;

public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(p => p.Description).MaximumLength(200).WithMessage("Post description cannot exceed 200 characters");
    }
}
