using BeeShop_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.BusinessLogic.Contracts
{
    public interface IAuthBusinessLogic
    {
        Task<Users> ProcessAuthenticate(LoginCredentials loginCredentials);
        Task<Users> ProcessAuthenticateWithRecaptcha(LoginCredentials loginCredentials);
        Task ProcessLogout(string refreshToken, Guid userId);
        Task ProcessLogoutEverywhere(Guid userId);
        Task<TokenModel> ProcessRefreshToken(TokenModel tokenModel);
        Task<Users> ProcessRegisterUser(RegisterUser registerUser);
        Task<Users> ProcessRegisterUserWithRecaptcha(RegisterUser registerUser);
    }
}
