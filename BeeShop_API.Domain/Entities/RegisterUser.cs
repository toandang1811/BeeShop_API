﻿namespace BeeShop_API.Domain.Entities
{
    public class RegisterUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Recaptcha { get; set; } = string.Empty;
    }
}
