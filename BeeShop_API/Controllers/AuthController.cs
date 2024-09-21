using BeeShop_API.BusinessLogic.Contracts;
using BeeShop_API.Domain.Entities;
using BeeShop_API.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BeeShop_API.Controllers
{
    [Authorize]
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusinessLogic authBusinessLogic;
        private readonly ITokenService tokenService;

        public AuthController(IAuthBusinessLogic authBusinessLogic, ITokenService tokenService)
        {
            this.authBusinessLogic = authBusinessLogic;
            this.tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            return new ObjectResult(await authBusinessLogic.ProcessRegisterUser(registerUser));
        }

        [AllowAnonymous]
        [HttpPost("register-mobile")]
        public async Task<IActionResult> RegisterMobile([FromBody] RegisterUser registerUser)
        {
            return new ObjectResult(await authBusinessLogic.ProcessRegisterUser(registerUser));
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginCredentials loginCredentials)
        {
            return new ObjectResult(await authBusinessLogic.ProcessAuthenticateWithRecaptcha(loginCredentials));
        }

        [AllowAnonymous]
        [HttpPost("authenticate-mobile")]
        public async Task<IActionResult> AuthenticateMobile([FromBody] LoginCredentials loginCredentials)
        {
            var rs = new ObjectResult(await authBusinessLogic.ProcessAuthenticate(loginCredentials));
            return rs;
        }

        [AllowAnonymous]
        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenModel tokenModel)
        {
            return new ObjectResult(await authBusinessLogic.ProcessRefreshToken(tokenModel));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] TokenModel tokenModel)
        {
            await authBusinessLogic.ProcessLogout(tokenModel.RefreshToken, GetUserIdFromRequest());

            return Ok();
        }

        [HttpPost("logout-everywhere")]
        public async Task<IActionResult> LogoutEverywhere()
        {
            await authBusinessLogic.ProcessLogoutEverywhere(GetUserIdFromRequest());

            return Ok();
        }

        private Guid GetUserIdFromRequest()
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            var principal = tokenService.GetPrincipalFromExpiredToken(token);
            var userId = new Guid(principal.FindFirstValue(ClaimTypes.NameIdentifier));

            return userId;
        }
    }
}
