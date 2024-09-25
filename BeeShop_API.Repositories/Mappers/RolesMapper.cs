using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Mappers
{
    public class RolesMapper : IMapperCommon<DataAccess.Roles, Roles>
    {
        public Roles FillFromDataAccess(DataAccess.Roles obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new Domain.Entities.Roles
            {
                RoleId = obj.RoleId,
                RoleName = obj.RoleName,
            };
        }

        public DataAccess.Roles FillFromDomain(Roles obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new DataAccess.Roles
            {
                RoleId = obj.RoleId,
                RoleName = obj.RoleName,
            };
        }
    }
}
