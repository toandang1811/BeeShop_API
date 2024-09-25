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
        public async Task<DataSet> GetData(string sqlString, object[] parameters, CommandType commandType)
        {
            return DataProvider.Instance.GetData(commandType, sqlString, parameters);
        }

        public async Task<int> SaveData(string sqlString, object[] parameters, CommandType commandType)
        {
            return DataProvider.Instance.SaveData(commandType, sqlString, parameters);
        }

        public async Task<object> GetObject(string sqlString, object[] parameters, CommandType commandType)
        {
            return DataProvider.Instance.GetObject(commandType, sqlString, parameters);
        }
    }
}
