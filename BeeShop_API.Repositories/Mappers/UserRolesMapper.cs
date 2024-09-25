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
        private UserMapper uMapper;
        public UserRolesMapper() 
        {
            uMapper = new UserMapper();
        }
        public UserRoles FillFromDataAccess(DataAccess.UserRoles obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new Domain.Entities.UserRoles
            {
                RoleId = obj.RoleId,
                UserId = obj.UserId
            };
        }

        public DataAccess.UserRoles FillFromDomain(UserRoles obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new DataAccess.UserRoles
            {
                RoleId = obj.RoleId,
                UserId = obj.UserId,
                Role = new DataAccess.Roles() { RoleId = obj.Role.RoleId, RoleName = obj.Role.RoleName },
                User = uMapper.FillFromDomain(obj.User)
            };
        }
    }
}
