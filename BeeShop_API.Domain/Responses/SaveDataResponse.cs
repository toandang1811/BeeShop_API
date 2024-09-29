using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Domain.Responses
{
    public class SaveDataResponse : BaseResponse<int>
    {
        public int RowCountAffected {  get; set; }
    }
}
