﻿using BeeShop_API.DataAccess;
using BeeShop_API.Repositories.Contracts.Mappers;
using BeeShop_API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using UserSessions = BeeShop_API.Domain.Entities.UserSessions;
using BeeShop_API.Repositories.Mappers;

namespace BeeShop_API.Repositories
{
    public class UserSessionsRepository : BaseRepository, IUserSessionsRepository
    {
        private UserSessionMapper userSessionMapper;

        public UserSessionsRepository(DataContext context) : base(context)
        {
            this.userSessionMapper = new UserSessionMapper();
        }

        public async Task<bool> IsRefreshTokenValidForUser(string refreshToken, Guid userId)
        {
            return await DataContext.UserSessions.AnyAsync(userSession => userSession.UserId == userId &&
                    userSession.RefreshToken == refreshToken && userSession.ExpirationDate > DateTime.UtcNow);
        }

        public async Task Add(UserSessions userSession)
        {
            await DataContext.UserSessions.AddAsync(userSessionMapper.FillFromDomain(userSession));

            await DataContext.SaveChangesAsync();
        }

        public async Task DeleteByRefreshTokenAndUser(string refreshToken, Guid userId)
        {
            var userSession = await DataContext.UserSessions.FirstOrDefaultAsync(userSession => userSession.RefreshToken == refreshToken
                    && userSession.UserId == userId);

            if (userSession != null)
            {
                DataContext.UserSessions.Remove(userSession);
                await DataContext.SaveChangesAsync();
            }
        }

        public async Task DeleteByUserId(Guid userId)
        {
            var expiredUserSessions = await DataContext.UserSessions.Where(userSession => userSession.UserId == userId).ToListAsync();

            if (expiredUserSessions.Any())
            {
                DataContext.UserSessions.RemoveRange(expiredUserSessions);
                await DataContext.SaveChangesAsync();
            }
        }

        public async Task DeleteExpiredByUserId(Guid userId)
        {
            var expiredUserSessions = await DataContext.UserSessions.Where(userSession => userSession.UserId == userId &&
                    userSession.ExpirationDate < DateTime.UtcNow).ToListAsync();

            if (expiredUserSessions.Any())
            {
                DataContext.UserSessions.RemoveRange(expiredUserSessions);
                await DataContext.SaveChangesAsync();
            }
        }
    }
}
