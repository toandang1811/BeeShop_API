using BeeShop_API.DataAccess;
using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories
{
    public class ProductsRepository : BaseRepository
    {
        public ProductsRepository(DataContext context) : base(context)
        {

        }

        public async Task<Products> GetByUsernameWithPassword(string username)
        {
            try
            {
                var user = await DataContext.Users.FirstAsync(u => u.Username.ToLower() == username.ToLower());

                var result = userMapper.FillFromDataAccess(user);
                result.PasswordHash = user.PasswordHash;

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
