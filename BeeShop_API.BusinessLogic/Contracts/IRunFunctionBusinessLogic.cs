using BeeShop_API.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.BusinessLogic.Contracts
{
    public interface IRunFunctionBusinessLogic
    {
        Task<DataSet> GetData(string sqlString, object[] parameters);
        Task<DataSet> GetDataByProc(string sqlString, object[] parameters);
        Task<int> SaveData(string sqlString, object[] parameters);
        Task<int> SaveDataByProc(string sqlString, object[] parameters);
        Task<object> GetObject (string sqlString, object[] parameters);
        Task<object> GetObjectByProc(string sqlString, object[] parameters);
    }
}
