using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Domain.Responses
{
    public class GetObjectResponse : BaseResponse
    {
        public object Data { get; set; }
    }
}
