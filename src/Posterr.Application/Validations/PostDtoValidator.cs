using FluentValidation;
using Posterr.Application.DTOs;

namespace Posterr.Application.Validations
{
    public class PostDtoValidator : AbstractValidator<PostDto>
    {
        public PostDtoValidator()
        {
            RuleFor(u => u.Content)
                .NotEmpty()
                .WithMessage("Content is empty.")
                .MaximumLength(777)
                .WithMessage("Content has more than 777 characters.");
        }
    }
}
