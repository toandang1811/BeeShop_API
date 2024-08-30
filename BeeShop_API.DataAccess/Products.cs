using BeeShop_API.DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.DataAccess
{
    public class Products : CommonAbstracts
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
    }
}
