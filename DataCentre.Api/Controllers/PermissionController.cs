using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models;
using DataCentre.Api.PreProcess;
using DataCentre.Api.View;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/data")]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    public class PermissionController : BaseController
    {
        public PermissionController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper) : base(Logger, RepositoryWrapper)
        {

        }
        [HttpGet]
        public ApiResult<ResultView> Get(int id)
        {
            ApiResult<ResultView> apiResult = new ApiResult<ResultView>();
            try
            {
                ResultView view = new ResultView();
                RequestBody = JsonConvert.SerializeObject(new { id = id });
                var privList = _repositoryWrapper.PrivilegeData.Query(@"SELECT a.p_id id, a.p_privilege_name name, a.p_privilege_type type, case when c.id is null then false else true end isHave FROM PrivilegeData a
                                                                        LEFT OUTER JOIN UserPrivileges b on a.p_id = b.PrivilegeId
                                                                        LEFT OUTER JOIN LoginData c on b.PrivilegeGroup = c.l_privilege_group and c.id=@id", new { id = id });
                view.data = privList;
                apiResult.Code = "0000";
                apiResult.Message = "";
                apiResult.Result = view;
                return apiResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                apiResult.Code = "9999";
                apiResult.Message = "系統發生錯誤，請洽系統管理人員";
                return apiResult;
            }
        }
        [HttpPut]
        public string Put(object data)
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                return Utility.Utility.GetFailJsonStr("9999", "系統發生錯誤，請洽系統管理人員");
            }
        }
    }
}
