using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Domain.Responses
{
    public class GetDataResponse : BaseResponse
    {
        public DataSet Data {  get; set; }
    }
}
