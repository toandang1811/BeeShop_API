using BeeShop_API.Domain.Entities;
using BeeShop_API.Repositories.Contracts;
using BeeShop_API.Repositories.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace BeeShop_API.Repositories
{
    public class UserRolesRepository : BaseRepository, IUserRolesRepository
    {
        private UserRolesMapper mapper;
        private RolesMapper roleMapper;
        public UserRolesRepository(DataAccess.DataContext context) : base(context)
        {
            mapper = new UserRolesMapper();
            roleMapper = new RolesMapper();
        }

        public async Task<UserRoles> AddRoleToUser(Guid UserId, string RoleId)
        {
            var userRole = new Domain.Entities.UserRoles()
            {
                UserId = UserId,
                RoleId = RoleId
            };
            var urAfter = await DataContext.UserRoles.AddAsync(mapper.FillFromDomain(userRole));
            await DataContext.SaveChangesAsync();

            return mapper.FillFromDataAccess(urAfter.Entity);
        }

        public async Task<bool> Delete(Guid UserId, string RoleId)
        {
            var userRole = await DataContext.UserRoles.FirstAsync(x => x.UserId == UserId && x.RoleId == RoleId);
            DataContext.UserRoles.Remove(userRole);
            return await DataContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<UserRoles>> GetAll(string? txtSearch, int? page)
        {
            List<UserRoles> listUserRole = new List<UserRoles>();
            var pageSize = 10;
            page ??= 1;
            IQueryable<DataAccess.UserRoles> items = DataContext.UserRoles.Select(x => x);
            if (!string.IsNullOrEmpty(txtSearch))
            {
                items = items.Where(x => x.RoleId.Contains(txtSearch));
            }

            var pagedItems = items.ToPagedList(page.Value, pageSize);

            foreach (var item in pagedItems)
            {
                listUserRole.Add(mapper.FillFromDataAccess(item));
            }
            return listUserRole.AsEnumerable();
        }

        public async Task<IEnumerable<Domain.Entities.UserRoles>> GetRolesByUserId(Guid UserId)
        {
            List<Domain.Entities.UserRoles> userRoles = new List<UserRoles>();
            var items = await DataContext.UserRoles.Where(x => x.UserId == UserId).ToListAsync();
            foreach (var item in items) 
            {
                userRoles.Add(mapper.FillFromDataAccess(item));
            }
            return userRoles;
        }
    }
}
