using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Domain.Requests
{
    public class RunSQLDataRequest
    {
        public string SqlString { get; set; }
        public object[] Parameters { get; set; }
    }
}
