using FluentValidation;
using BeeShop_API.Domain.Validators;

namespace BeeShop_API.Domain.Entities
{
    public class UserSessions
    {
        private static UserSessionValidator userSessionValidator = new UserSessionValidator();

        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string IpAddress { get; set; }

        public void ValidateAndThrow()
        {
            userSessionValidator.ValidateAndThrow(this);
        }
    }
}
