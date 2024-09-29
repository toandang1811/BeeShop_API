using BeeShop_API.BusinessLogic.Contracts;
using BeeShop_API.Domain.Responses;
using BeeShop_API.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeShop_API.BusinessLogic
{
    public class RunFunctionBusinessLogic : IRunFunctionBusinessLogic
    {
        private readonly IRunFunctionRepository _repository;
        public RunFunctionBusinessLogic(IRunFunctionRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Dictionary<int, List<Dictionary<string, object>>>> GetData(string sqlString, string[] parameters = null, object[] values = null)
        {
            Dictionary<int, List<Dictionary<string, object>>> data = new Dictionary<int, List<Dictionary<string, object>>>();
            DataSet ds = await _repository.GetData(sqlString, parameters, values, CommandType.Text);
            if (ds != null)
            {
                int i = 0;
                foreach (DataTable table in ds.Tables) 
                {
                    List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                    foreach (DataRow row in table.Rows)
                    {
                        Dictionary<string, object> dict = new Dictionary<string, object>();
                        foreach (DataColumn col in table.Columns)
                        {
                            dict.Add(col.ColumnName, row[col.ColumnName]);
                        }
                        list.Add(dict);
                    }
                    data.Add(i, list);
                    i++;
                }
            }
            return data;
        }

        public async Task<Dictionary<int, List<Dictionary<string, object>>>> GetDataByProc(string sqlString, string[] parameters = null, object[] values = null)
        {
            Dictionary<int, List<Dictionary<string, object>>> data = new Dictionary<int, List<Dictionary<string, object>>>();
            DataSet ds = await _repository.GetData(sqlString, parameters, values, CommandType.StoredProcedure);
            if (ds != null)
            {
                int i = 0;
                foreach (DataTable table in ds.Tables)
                {
                    List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                    foreach (DataRow row in table.Rows)
                    {
                        Dictionary<string, object> dict = new Dictionary<string, object>();
                        foreach (DataColumn col in table.Columns)
                        {
                            dict.Add(col.ColumnName, row[col.ColumnName]);
                        }
                        list.Add(dict);
                    }
                    data.Add(i, list);
                    i++;
                }
            }
            return data;
        }

        public async Task<object> GetObject(string sqlString, string[] parameters = null, object[] values = null)
        {
            return  await _repository.GetObject(sqlString, parameters, values, CommandType.Text);
        }

        public async Task<object> GetObjectByProc(string sqlString, string[] parameters = null, object[] values = null)
        {
            return await _repository.GetObject(sqlString, parameters, values, CommandType.StoredProcedure);
        }

        public async Task<int> SaveData(string sqlString, string[] parameters = null, object[] values = null)
        {
            return await _repository.SaveData(sqlString, parameters, values, CommandType.Text);
        }

        public async Task<int> SaveDataByProc(string sqlString, string[] parameters = null, object[] values = null)
        {
            return await _repository.SaveData(sqlString, parameters, values, CommandType.StoredProcedure);
        }
    }
}
