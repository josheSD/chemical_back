using chemical.back.DTO;
using FluentValidation;

namespace chemical.back.Validator
{
    public class UserRemoveDtoValidator : AbstractValidator<UserRemoveDto>
    {
        public UserRemoveDtoValidator()
        {

            RuleFor(x => x.UserId)
                .NotNull();

            RuleFor(x => x.UserState)
                .NotNull();

        }
    }
}
