using BeeShop_API.BusinessLogic;
using BeeShop_API.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeShop_API.Controllers
{
    [Authorize]
    [Route("v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("get-all")]
        public async Task<IActionResult> ProductGetAll([FromBody] LoginCredentials loginCredentials)
        {
            var rs = new ObjectResult(await authBusinessLogic.ProcessAuthenticate(loginCredentials));
            return rs;
        }
    }
}
