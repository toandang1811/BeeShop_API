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
    public class UserSessionMapper : IMapperCommon<DataAccess.UserSessions, Domain.Entities.UserSessions>
    {
        public Domain.Entities.UserSessions FillFromDataAccess(DataAccess.UserSessions obj)
        {
            throw new NotImplementedException();
        }

        public DataAccess.UserSessions FillFromDomain(Domain.Entities.UserSessions obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return new DataAccess.UserSessions
            {
                SessionId = obj.SessionId,
                UserId = obj.UserId,
                RefreshToken = obj.RefreshToken,
                ExpirationDate = obj.ExpirationDate,
                IpAddress = obj.IpAddress
            };
        }
    }
}
