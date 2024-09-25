using BeeShop_API.BusinessLogic.Contracts;
using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.BusinessLogic
{
    public class RolesBusinessLogic : IRolesBusinessLogic
    {
        private readonly IRolesRepository _rolesRepository;
        public RolesBusinessLogic(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository; 
        }
        public async Task<Roles> Add(string RoleId, string RoleName)
        {
            return await _rolesRepository.Add(RoleId, RoleName);
        }

        public async Task<bool> Delete(string RoleId)
        {
            return await _rolesRepository.Delete(RoleId);
        }
    }
}
