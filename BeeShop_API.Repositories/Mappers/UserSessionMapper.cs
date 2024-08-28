using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Mappers
{
    public class UserSessionMapper : IUserSessionMapper
    {
        public DataAccess.UserSessions FillFromDomain(UserSessions userSession)
        {
            if (userSession is null)
            {
                throw new ArgumentNullException(nameof(userSession));
            }

            return new DataAccess.UserSessions
            {
                SessionId = userSession.SessionId,
                UserId = userSession.UserId,
                RefreshToken = userSession.RefreshToken,
                ExpirationDate = userSession.ExpirationDate,
                IpAddress = userSession.IpAddress
            };
        }
    }
}
