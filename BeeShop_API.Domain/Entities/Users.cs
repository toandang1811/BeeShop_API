using FluentValidation;
using BeeShop_API.Domain.Validators;
using BeeShop_API.Domain.Entities.Abstracts;

namespace BeeShop_API.Domain.Entities
{
    public class Users : CommonEFAbstract
    {
        private static UserValidator userValidator = new UserValidator();

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public override void ValidateAndThrow()
        {
            userValidator.ValidateAndThrow(this);
        }
    }
}
