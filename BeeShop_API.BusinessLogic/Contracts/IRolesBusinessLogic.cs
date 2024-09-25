using BeeShop_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.BusinessLogic.Contracts
{
    public interface IRolesBusinessLogic
    {
        Task<Roles> Add(string RoleId, string RoleName);
        Task<bool> Delete(string RoleId);
    }
}
