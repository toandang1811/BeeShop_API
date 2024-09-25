using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories.Contracts
{
    public interface IRunFunctionRepository
    {
        Task<DataSet> GetData(string sqlString, object[] parameters, CommandType commandType);
        Task<int> SaveData(string sqlString, object[] parameters, CommandType commandType);
        Task<object> GetObject(string sqlString, object[] parameters, CommandType commandType);
    }
}
