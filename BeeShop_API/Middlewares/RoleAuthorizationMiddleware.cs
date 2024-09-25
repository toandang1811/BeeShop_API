using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BeeShop_API.Middlewares
{
    public class RoleAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string[] _requiredRoles;

        public RoleAuthorizationMiddleware(RequestDelegate next, IOptions<RoleAuthorizationOptions> options)
        {
            _next = next;
            _requiredRoles = options.Value.RequiredRoles;
        }

        public async Task Invoke(HttpContext context)
        {
            //var bypassAuthPaths = new List<string>
            //{
            //    "/v1/auth/register", 
            //    "/v1/auth/register-mobile",
            //    "/v1/auth/authenticate",
            //    "/v1/auth/authenticate-mobile",
            //    "/v1/auth/refreshToken"
            //};

            //var requestPath = context.Request.Path.Value.ToLower();

            //// Nếu request đến từ route xác thực thì bỏ qua kiểm tra token
            //if (bypassAuthPaths.Any(path => requestPath.Contains(path.ToLower())))
            //{
            //    await _next(context); // Cho phép tiếp tục request
            //    return;
            //}

            //var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            //if (string.IsNullOrEmpty(token))
            //{
            //    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    return;
            //}

            //var handler = new JwtSecurityTokenHandler();
            //var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            //if (jwtToken == null)
            //{
            //    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    return;
            //}

            //var roles = jwtToken.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            //if (!roles.Contains("ADMIN") && !roles.Contains("EMPLOYEE"))
            //{
            //    context.Response.StatusCode = StatusCodes.Status403Forbidden;
            //    return;
            //}

            await _next(context); // Nếu thành công, cho phép tiếp tục
        }
    }

    public class RoleAuthorizationOptions
    {
        public string[] RequiredRoles { get; set; }
    }
}
