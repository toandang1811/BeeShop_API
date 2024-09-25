using BeeShop_API.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.DataAccess
{
    [Table(name: "UserRoles")]
    public class UserRoles
    {
        public Guid UserId { get; set; }
        public string RoleId { get; set; }
        public Users User { get; set; }
        public Roles Role { get; set; }
    }
}
