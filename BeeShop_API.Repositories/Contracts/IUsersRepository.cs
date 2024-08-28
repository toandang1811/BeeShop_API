using BeeShop_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts
{
    public interface IUsersRepository
    {
        Task<Users> Add(Users user);
        Task<bool> EmailExists(string email);
        Task<Users> GetByEmailWithPassword(string email);
        Task<Users> GetByUsernameWithPassword(string username);
        Task<bool> UsernameExists(string username);
    }
}
