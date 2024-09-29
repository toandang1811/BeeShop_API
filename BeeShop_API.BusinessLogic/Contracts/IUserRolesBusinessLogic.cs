using BeeShop_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.BusinessLogic.Contracts
{
    public interface IUserRolesBusinessLogic
    {
        Task<UserRoles> AddRoleToUser(Guid UserId, string RoleId);
        //Task<UserRoles> Update(UserRoles pc);
        Task<IEnumerable<UserRoles>> GetAll(string? txtSearch, int? page);
        Task<bool> Delete(Guid UserId, string RoleId);
        Task<bool> CheckHasRole(Guid UserId, string RoleId);
    }
}
