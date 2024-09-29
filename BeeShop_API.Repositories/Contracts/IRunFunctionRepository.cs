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
        Task<DataSet> GetData(string sqlString, string[] parameters, object[] values, CommandType commandType);
        Task<int> SaveData(string sqlString, string[] parameters, object[] values, CommandType commandType);
        Task<object> GetObject(string sqlString, string[] parameters, object[] values, CommandType commandType);
    }
}
