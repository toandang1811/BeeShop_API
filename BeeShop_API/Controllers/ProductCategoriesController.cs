using BeeShop_API.Attributes;
using BeeShop_API.BusinessLogic.Contracts;
using BeeShop_API.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeeShop_API.Controllers
{
    [RoleAuthorize("ADMIN", "EMPLOYEE")]
    [Route("v1/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesBusinessLogic _pcBL;
        public ProductCategoriesController(IProductCategoriesBusinessLogic pcBL)
        {
            this._pcBL = pcBL;
        }

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(string ? txtSearch, int ? page)
        {
            return new ObjectResult(await _pcBL.GetAll(txtSearch, page));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductCategories pc)
        {
            return new ObjectResult(await _pcBL.Add(pc));
        }
    }
}
