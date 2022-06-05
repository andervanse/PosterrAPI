using FluentValidation;
using Posterr.Application.DTOs;

namespace Posterr.Application.Validations
{
    public class UserDtoValidator: AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Name is empty.")
                .MaximumLength(14)
                .WithMessage("Name has more than 14 characters.")
                .Matches(@"^[a-zA-Z0-9]*$")
                .WithMessage("Name must have only alphanumerical characters.");
        }
    }

    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Name is empty.")
                .MaximumLength(14)
                .WithMessage("Name has more than 14 characters.")
                .Matches(@"^[a-zA-Z0-9]*$")
                .WithMessage("Name must have only alphanumerical characters.");
        }
    }
}
