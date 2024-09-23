using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.DataAccess
{
    [Table(name: "Users")]
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
