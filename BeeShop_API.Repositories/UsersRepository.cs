using BeeShop_API.DataAccess;
using BeeShop_API.Repositories.Contracts.Mappers;
using BeeShop_API.Repositories.Contracts;
using BeeShop_API.Repositories;
using Microsoft.EntityFrameworkCore;
using User = BeeShop_API.Domain.Entities.Users;
using BeeShop_API.Repositories.Mappers;

namespace BeeShop_API.Repositories
{
    public class UsersRepository : BaseRepository, IUsersRepository
    {
        private UserMapper _mapper;
        public UsersRepository(DataContext context) : base(context)
        {
            _mapper = new UserMapper();
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await DataContext.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<bool> EmailExists(string email)
        {
            return await DataContext.Users.AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User> GetByUsernameWithPassword(string username)
        {
            try
            {
                var user = await DataContext.Users.FirstAsync(u => u.Username.ToLower() == username.ToLower());

                var result = _mapper.FillFromDataAccess(user);
                result.PasswordHash = user.PasswordHash;

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<User> GetByEmailWithPassword(string email)
        {
            var user = await DataContext.Users.FirstAsync(u => u.Email.ToLower() == email.ToLower());

            User result = _mapper.FillFromDataAccess(user);
            result.PasswordHash = user.PasswordHash;

            return result;
        }

        public async Task<User> Add(User user)
        {
            user.ValidateAndThrow();

            await DataContext.Users.AddAsync(_mapper.FillFromDomain(user));
            await DataContext.SaveChangesAsync();

            user.PasswordHash = null;
            return user;
        }
    }
}