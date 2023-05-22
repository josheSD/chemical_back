using chemical.back.DTO;
using FluentValidation;

namespace chemical.back.Validator
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator() 
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100)
                .Matches("^[a-zA-ZñÑáéíóúÁÉÍÓÚ0-9]+(?:\\s?[a-zA-ZñÑáéíóúÁÉÍÓÚ0-9]+)*$").WithMessage("'{PropertyName}' No cumple con la expresión regular");

            RuleFor(x => x.UserPassword)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255)
                .Matches("^[a-zA-ZñÑáéíóúÁÉÍÓÚ0-9]+(?:\\s?[a-zA-ZñÑáéíóúÁÉÍÓÚ0-9]+)*$").WithMessage("'{PropertyName}' No cumple con la expresión regular");

            RuleFor(x => x.UserState)
                .NotNull();

        }
    }
}
