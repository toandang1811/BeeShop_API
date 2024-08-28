using BeeShop_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts
{
    public interface IUserSessionsRepository
    {
        Task Add(UserSessions userSession);
        Task DeleteByRefreshTokenAndUser(string refreshToken, Guid userId);
        Task DeleteByUserId(Guid userId);
        Task DeleteExpiredByUserId(Guid userId);
        Task<bool> IsRefreshTokenValidForUser(string refreshToken, Guid userId);
    }
}
