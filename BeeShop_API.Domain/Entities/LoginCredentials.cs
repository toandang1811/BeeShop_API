namespace BeeShop_API.Domain.Entities
{
    public class LoginCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public string Recaptcha { get; set; }
    }
}
