using BeeShop_API.DataAccess;
using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Mappers
{
    public class UserMapper : IMapperCommon<DataAccess.Users, Domain.Entities.Users>
    {
        public Domain.Entities.Users FillFromDataAccess(DataAccess.Users obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new Domain.Entities.Users
            {
                UserId = obj.UserId,
                Username = obj.Username,
                Email = obj.Email,
                PasswordHash = obj.PasswordHash,
            };
        }

        public DataAccess.Users FillFromDomain(Domain.Entities.Users obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new DataAccess.Users
            {
                UserId = obj.UserId,
                Username = obj.Username,
                PasswordHash = obj.PasswordHash,
                Email = obj.Email
            };
        }
    }
}
