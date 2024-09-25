using BeeShop_API.Attributes;
using BeeShop_API.BusinessLogic.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeShop_API.Controllers
{
    [RoleAuthorize("ADMIN")]
    [Route("v1/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesBusinessLogic _rolesBusinessLogic;
        public RolesController(IRolesBusinessLogic rolesBusinessLogic)
        {
            _rolesBusinessLogic = rolesBusinessLogic;
        }

        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> Add(string RoleId, string RoleName)
        {
            return new ObjectResult(await _rolesBusinessLogic.Add(RoleId, RoleName));
        }

        [AllowAnonymous]
        [HttpPost("delete")]
        public async Task<IActionResult> Delete(string RoleId)
        {
            return new ObjectResult(await _rolesBusinessLogic.Delete(RoleId));
        }
    }
}
