using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts.Mappers
{
    public interface IUserSessionMapper
    {
        DataAccess.UserSession FillFromDomain(Domain.Entities.UserSession userSession);
    }
}
