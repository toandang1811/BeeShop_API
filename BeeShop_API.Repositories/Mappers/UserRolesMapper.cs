using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Mappers
{
    public class UserRolesMapper : IMapperCommon<DataAccess.UserRoles, UserRoles>
    {
        public UserRoles FillFromDataAccess(DataAccess.UserRoles obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new Domain.Entities.UserRoles
            {
                RoleId = obj.RoleId,
                UserId = obj.UserId,
                Role = new Roles() { RoleId = obj.Role.RoleId, RoleName = obj.Role.RoleName },
                User = new Users() { UserId = obj.UserId },
            };
        }

        public DataAccess.UserRoles FillFromDomain(UserRoles obj)
        {
            throw new NotImplementedException();
        }
    }
}
