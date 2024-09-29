using BeeShop_API.Attributes;
using BeeShop_API.BusinessLogic.Contracts;
using BeeShop_API.Domain.Entities;
using BeeShop_API.Domain.Requests;
using BeeShop_API.Domain.Responses;
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
        private readonly IUserRolesBusinessLogic userRolesBusinessLogic;

        public AuthController(IAuthBusinessLogic authBusinessLogic, ITokenService tokenService, IUserRolesBusinessLogic userRolesBusinessLogic)
        {
            this.authBusinessLogic = authBusinessLogic;
            this.tokenService = tokenService;
            this.userRolesBusinessLogic = userRolesBusinessLogic;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            BaseResponse<Users> rp = new BaseResponse<Users>();
            rp.IsError = false;
            rp.ErrorMessage = "";
            rp.Data = new Users();
            try
            {
                rp.IsError = false;
                rp.ErrorMessage = "";
                rp.Data = await authBusinessLogic.ProcessRegisterUser(registerUser);
            }
            catch (Exception ex) 
            {
                rp.IsError = true;
                rp.ErrorMessage = ex.Message;
            }
            return Ok(rp);
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
            BaseResponse<Users> rp = new BaseResponse<Users>();
            rp.IsError = false;
            rp.ErrorMessage = "";
            rp.Data = new Users();
            try
            {
                rp.IsError = false;
                rp.ErrorMessage = "";
                rp.Data = await authBusinessLogic.ProcessAuthenticate(loginCredentials);
            }
            catch (Exception ex)
            {
                rp.IsError = true;
                rp.ErrorMessage = ex.Message;
            }
            return Ok(rp);
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
            BaseResponse<bool> rp = new BaseResponse<bool>();
            rp.IsError = false;
            rp.ErrorMessage = "";
            rp.Data = false;
            try
            {
                await authBusinessLogic.ProcessLogout(tokenModel.RefreshToken, GetUserIdFromRequest());
                rp.IsError = false;
                rp.ErrorMessage = "";
                rp.Data = true;
            }
            catch (Exception ex)
            {
                rp.IsError = true;
                rp.ErrorMessage = ex.Message;
            }
            return Ok(rp);
        }

        [HttpPost("logout-everywhere")]
        public async Task<IActionResult> LogoutEverywhere()
        {
            await authBusinessLogic.ProcessLogoutEverywhere(GetUserIdFromRequest());

            return Ok();
        }

        [HttpPost("check-authorization")]        
        public async Task<IActionResult> CheckAuthorization()
        {
            bool status = false;
            if (!string.IsNullOrEmpty(GetUserIdFromRequest().ToString()))
            {
                status = true;
            }
            return Ok(status);
        }

        [HttpPost("check-permission")]
        public async Task<IActionResult> CheckPermission(CheckPermissionrequest roles)
        {
            BaseResponse<bool> rp = new BaseResponse<bool>() { IsError = false, ErrorMessage = "", Data = false };
            string[] items = roles.Roles.Trim().Split(',');
            try
            {
                foreach (string item in items)
                {
                    if (await userRolesBusinessLogic.CheckHasRole(GetUserIdFromRequest(), item))
                    {
                        rp.IsError = false;
                        rp.ErrorMessage = "";
                        rp.Data = true;
                        break;
                    }
                }
            }
            catch (Exception ex) 
            {
                rp.IsError = true;
                rp.ErrorMessage = $"Đã xảy ra lỗi: {ex.Message}";
                rp.Data = false;
            }
            return Ok(rp);
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
