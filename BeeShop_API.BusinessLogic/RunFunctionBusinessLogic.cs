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
        public async Task<DataSet> GetData(string sqlString, object[] parameters)
        {
            return await _repository.GetData(sqlString, parameters, CommandType.Text);
        }

        public async Task<DataSet> GetDataByProc(string sqlString, object[] parameters)
        {
            return await _repository.GetData(sqlString, parameters, CommandType.StoredProcedure);
        }

        public async Task<object> GetObject(string sqlString, object[] parameters)
        {
            return  await _repository.GetObject(sqlString, parameters, CommandType.Text);
        }

        public async Task<object> GetObjectByProc(string sqlString, object[] parameters)
        {
            return await _repository.GetObject(sqlString, parameters, CommandType.StoredProcedure);
        }

        public async Task<int> SaveData(string sqlString, object[] parameters)
        {
            return await _repository.SaveData(sqlString, parameters, CommandType.Text);
        }

        public async Task<int> SaveDataByProc(string sqlString, object[] parameters)
        {
            return await _repository.SaveData(sqlString, parameters, CommandType.StoredProcedure);
        }
    }
}
