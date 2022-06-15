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
        public ApiResult<ResultView> Put(PermissionView.PermissionData data)
        {
            ApiResult<ResultView> result = new ApiResult<ResultView>();
            IDbConnection conn = _repositoryWrapper.GetRepositoryContext().CreateConnection();
            conn.Open();
            IDbTransaction tran = conn.BeginTransaction();
            try
            {
                var LoginDatas = _repositoryWrapper.LoginData.FindByCondition(new { id = data.id }, tran);
                if(LoginDatas.Count() > 0)
                {
                    LoginData Login = LoginDatas.ToList()[0];
                    _repositoryWrapper.UserPrivilege.Delete(new UserPrivilege() { PrivilegeGroup = Login.PrivilegeGroup }, tran);
                    foreach(int ids in data.idList)
                    {
                        UserPrivilege Privilege = new UserPrivilege();
                        Privilege.PrivilegeGroup = Login.PrivilegeGroup;
                        Privilege.PrivilegeId = ids;
                        Privilege.CreateDate = DateTime.Now;
                        _repositoryWrapper.UserPrivilege.Create(Privilege, tran);
                    }
                    result.Code = "0000";
                }
                else
                {
                    result.Code = "9999";
                    result.Message = "未知的錯誤，找不到帳號相關資訊";
                }
                tran.Commit();
                return result;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                _logger.LogError(ex + ex.StackTrace);
                result.Code = "9999";
                result.Message = "未知的錯誤，請洽系統管理人員";
                return result;
            }
        }
    }
}
