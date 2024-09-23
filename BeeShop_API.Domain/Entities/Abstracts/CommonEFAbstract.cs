using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Domain.Entities.Abstracts
{
    public abstract class CommonEFAbstract
    {
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedUserID { get; set; }
        public abstract void ValidateAndThrow();
    }
}
