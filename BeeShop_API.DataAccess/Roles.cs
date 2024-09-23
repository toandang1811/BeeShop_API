using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.DataAccess
{
    public class Roles
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
