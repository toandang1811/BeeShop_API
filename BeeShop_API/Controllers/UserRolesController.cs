using BeeShop_API.Attributes;
using BeeShop_API.BusinessLogic.Contracts;
using BeeShop_API.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeeShop_API.Controllers
{
    [RoleAuthorize("ADMIN")]
    [Route("v1/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesBusinessLogic urBussiness;
        public UserRolesController(IUserRolesBusinessLogic urBussiness)
        {
            this.urBussiness = urBussiness;
        }

        [AllowAnonymous]
        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(string ? txtSeach, int ? page)
        {
            return new ObjectResult(await urBussiness.GetAll(txtSeach, page));
        }

        [AllowAnonymous]
        [HttpPost("add-role-to-user")]
        public async Task<IActionResult> AddRoleToUser(Guid UserId, string RoleId)
        {
            return new ObjectResult(await urBussiness.AddRoleToUser(UserId, RoleId));
        }

        [AllowAnonymous]
        [HttpPost("remove-role-user")]
        public async Task<IActionResult> RemoveRoleUser(Guid UserId, string RoleId)
        {
            return new ObjectResult(await urBussiness.Delete(UserId, RoleId));
        }
    }
}
