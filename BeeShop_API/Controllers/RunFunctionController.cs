using BeeShop_API.BusinessLogic;
using BeeShop_API.BusinessLogic.Contracts;
using BeeShop_API.Domain.Requests;
using BeeShop_API.Domain.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;

namespace BeeShop_API.Controllers
{
    [Authorize]
    [Route("v1/[controller]")]
    [ApiController]
    public class RunFunctionController : ControllerBase
    {
        private readonly IRunFunctionBusinessLogic runFunctionBusinessLogic;
        public RunFunctionController(IRunFunctionBusinessLogic runFunctionBusinessLogic)
        {
            this.runFunctionBusinessLogic = runFunctionBusinessLogic;
        }

        [HttpPost("get-data")]
        public async Task<IActionResult> GetData([FromBody] RunSQLDataRequest request)
        {
            GetDataResponse res = new GetDataResponse();

            try
            {
                res.Data = await runFunctionBusinessLogic.GetData(request.SqlString, request.Parameters);
            }
            catch (Exception ex) 
            {
                res.IsError = true;
                res.ErrorMessage = ex.Message;
            }
            string jsonString = JsonConvert.SerializeObject(res);
            return Ok(jsonString);
        }

        [HttpPost("get-data-by-proc")]
        public async Task<IActionResult> GetDataByProc([FromBody] RunSQLDataRequest request)
        {
            GetDataResponse res = new GetDataResponse();
            try
            {
                res.Data = await runFunctionBusinessLogic.GetDataByProc(request.SqlString, request.Parameters);
            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorMessage = ex.Message;
            }
            string jsonString = JsonConvert.SerializeObject(res);
            return Ok(jsonString);
        }

        [HttpPost("save-data")]
        public async Task<IActionResult> SaveData([FromBody] RunSQLDataRequest request)
        {
            SaveDataResponse res = new SaveDataResponse();
            try
            {
                res.RowCountAffected = await runFunctionBusinessLogic.SaveData(request.SqlString, request.Parameters);
            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorMessage = ex.Message;
            }
            string jsonString = JsonConvert.SerializeObject(res);
            return Ok(jsonString);
        }

        [HttpPost("save-data-by-proc")]
        public async Task<IActionResult> SaveDataByProc([FromBody] RunSQLDataRequest request)
        {
            SaveDataResponse res = new SaveDataResponse();
            try
            {
                res.RowCountAffected = await runFunctionBusinessLogic.SaveDataByProc(request.SqlString, request.Parameters);
            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorMessage = ex.Message;
            }
            string jsonString = JsonConvert.SerializeObject(res);
            return Ok(jsonString);
        }

        [HttpPost("get-object")]
        public async Task<IActionResult> GetObject([FromBody] RunSQLDataRequest request)
        {
            GetObjectResponse res = new GetObjectResponse();
            try
            {
                res.Data = await runFunctionBusinessLogic.GetObject(request.SqlString, request.Parameters);
            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorMessage = ex.Message;
            }
            string jsonString = JsonConvert.SerializeObject(res);
            return Ok(jsonString);
        }

        [HttpPost("get-object-by-proc")]
        public async Task<IActionResult> GetObjectByProc([FromBody] RunSQLDataRequest request)
        {
            GetObjectResponse res = new GetObjectResponse();
            try
            {
                res.Data = await runFunctionBusinessLogic.GetObjectByProc(request.SqlString, request.Parameters);
            }
            catch (Exception ex)
            {
                res.IsError = true;
                res.ErrorMessage = ex.Message;
            }
            string jsonString = JsonConvert.SerializeObject(res);
            return Ok(jsonString);
        }
    }
}
