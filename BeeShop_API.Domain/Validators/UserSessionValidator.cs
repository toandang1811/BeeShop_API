using FluentValidation;
using BeeShop_API.Domain.Entities;

namespace BeeShop_API.Domain.Validators
{
    public class UserSessionValidator : AbstractValidator<UserSession>
    {
        public UserSessionValidator()
        {
            RuleFor(session => session.IpAddress)
                .Length(0, 64);
        }
    }
}
