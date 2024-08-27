using FluentValidation;
using BeeShop_API.Domain.Entities;

namespace BeeShop_API.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Username)
                .NotEmpty()
                .Length(1, 256);
            RuleFor(user => user.Email)
                .NotEmpty()
                .Length(1, 256)
                .EmailAddress();
        }
    }
}
