using BeeShop_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts
{
    public interface IRolesRepository
    {
        Task<Roles> Add(string RoleId, string RoleName);
        Task<bool> Delete(string RoleId);
        Task<Roles> GetById(string RoleId);
    }
}
