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
    public class UserRolesBusinessLogic : IUserRolesBusinessLogic
    {
        private readonly IUserRolesRepository repository;
        public UserRolesBusinessLogic(IUserRolesRepository repository)
        {
            this.repository = repository;
        }
        public async Task<UserRoles> AddRoleToUser(Guid UserId, string RoleId)
        {
            return await repository.AddRoleToUser(UserId, RoleId);
        }

        public async Task<bool> Delete(Guid UserId, string RoleId)
        {
            return await repository.Delete(UserId, RoleId);
        }

        public async Task<IEnumerable<UserRoles>> GetAll(string? txtSearch, int? page)
        {
            return await repository.GetAll(txtSearch, page);
        }

        public async Task<bool> CheckHasRole(Guid UserId, string RoleId)
        {
            return await repository.CheckHasRole(UserId, RoleId);
        }
    }
}
