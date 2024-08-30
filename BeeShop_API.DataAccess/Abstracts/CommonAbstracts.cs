using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.DataAccess.Abstracts
{
    public abstract class CommonAbstracts
    {
        public DateTime CreatedDate { get; set; }
        public Guid CreatedUserID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid ModifiedUserID { get; set; }
    }
}
