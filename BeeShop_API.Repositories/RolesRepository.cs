using BeeShop_API.DataAccess;
using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts;
using BeeShop_API.Repositories.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories
{
    public class RolesRepository : BaseRepository, IRolesRepository
    {
        private RolesMapper _mapper;
        public RolesRepository(DataContext context) : base(context) 
        {
            this._mapper = new RolesMapper();
        }

        public async Task<Domain.Entities.Roles> Add(string RoleId, string RoleName)
        {
            var role = new Domain.Entities.Roles() { RoleId = RoleId, RoleName = RoleName };
            await DataContext.AddAsync(_mapper.FillFromDomain(role));
            await DataContext.SaveChangesAsync();

            return role;
        }

        public async Task<bool> Delete(string RoleId)
        {
            var role = await DataContext.Roles.FindAsync(RoleId);
            if (role != null)
            {
                DataContext.Roles.Remove(role);
                return await DataContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<Domain.Entities.Roles> GetById(string RoleId)
        {
            var role = await DataContext.Roles.FindAsync(RoleId);
            if (role != null)
            {
                return _mapper.FillFromDataAccess(role);
            }
            return null;
        }
    }
}
