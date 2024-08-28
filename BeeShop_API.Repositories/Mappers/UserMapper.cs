using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Mappers
{
    public class UserMapper : IUserMapper
    {
        public DataAccess.Users FillFromDomain(Users user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return new DataAccess.Users
            {
                UserId = user.UserId,
                Username = user.Username,
                PasswordHash = user.PasswordHash,
                Email = user.Email
            };
        }

        public Users FillFromDataAccess(DataAccess.Users user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return new Users
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
            };
        }
    }
}
