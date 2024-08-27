using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Services.Contracts
{
    public interface ICryptoService
    {
        string GetPasswordHash(string password);
        bool VerifyPasswordHash(string hashedPassword, string password);
    }
}
