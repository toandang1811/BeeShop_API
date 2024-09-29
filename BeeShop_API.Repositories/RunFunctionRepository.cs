using BeeShop_API.DataAccess.Provider;
using BeeShop_API.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.Repositories
{
    public class RunFunctionRepository : IRunFunctionRepository
    {
        public async Task<DataSet> GetData(string sqlString, string[] parameters, object[] values, CommandType commandType)
        {
            return DataProvider.Instance.GetData(commandType, sqlString, parameters, values);
        }

        public async Task<int> SaveData(string sqlString, string[] parameters, object[] values, CommandType commandType)
        {
            return DataProvider.Instance.SaveData(commandType, sqlString, parameters, values);
        }

        public async Task<object> GetObject(string sqlString, string[] parameters, object[] values, CommandType commandType)
        {
            return DataProvider.Instance.GetObject(commandType, sqlString, parameters, values);
        }
    }
}
