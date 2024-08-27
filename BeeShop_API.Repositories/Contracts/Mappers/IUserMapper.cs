using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts.Mappers
{
    public interface IUserMapper
    {
        Domain.Entities.User FillFromDataAccess(DataAccess.User user);
        DataAccess.User FillFromDomain(Domain.Entities.User user);
    }
}
