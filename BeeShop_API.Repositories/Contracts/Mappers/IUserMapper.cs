using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts.Mappers
{
    public interface IUserMapper
    {
        Domain.Entities.Users FillFromDataAccess(DataAccess.Users user);
        DataAccess.Users FillFromDomain(Domain.Entities.Users user);
    }
}
