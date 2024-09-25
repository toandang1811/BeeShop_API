using BeeShop_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts
{
    public interface IUserRolesRepository
    {
        Task<UserRoles> AddRoleToUser(Guid UserId, string RoleId);
        //Task<UserRoles> Update(UserRoles pc);
        Task<IEnumerable<UserRoles>> GetAll(string ? txtSearch, int ? page);
        Task<bool> Delete(Guid UserId, string RoleId);
        Task<IEnumerable<Domain.Entities.UserRoles>> GetRolesByUserId(Guid UserId);
    }
}
