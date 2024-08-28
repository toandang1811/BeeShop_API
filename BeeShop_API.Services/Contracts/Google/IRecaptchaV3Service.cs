using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Services.Contracts.Google
{
    public interface IRecaptchaV3Service
    {
        Task<bool> ValidateReCaptchaResponse(string response);
    }
}
