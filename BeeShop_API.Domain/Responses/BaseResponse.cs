using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Domain.Responses
{
    public class BaseResponse
    {
        public bool IsError { get; set; } = false;
        public string ErrorMessage { get; set; } = "";
    }
}
