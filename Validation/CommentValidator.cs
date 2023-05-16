using FluentValidation;
using Data.Entities;

public class CommentValidator : AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(p => p.Content).MaximumLength(200).WithMessage("Comment content cannot exceed 200 characters");
    }
}
