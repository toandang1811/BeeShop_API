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
        Task<Dictionary<int, List<Dictionary<string, object>>>> GetData(string sqlString, string[] parameters = null, object[] values = null);
        Task<Dictionary<int, List<Dictionary<string, object>>>> GetDataByProc(string sqlString, string[] parameters = null, object[] values = null);
        Task<int> SaveData(string sqlString, string[] parameters = null, object[] values = null);
        Task<int> SaveDataByProc(string sqlString, string[] parameters = null, object[] values = null);
        Task<object> GetObject (string sqlString, string[] parameters = null, object[] values = null);
        Task<object> GetObjectByProc(string sqlString, string[] parameters = null, object[] values = null);
    }
}
