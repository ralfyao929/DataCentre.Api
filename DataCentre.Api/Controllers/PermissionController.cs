using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Localize;
using DataCentre.Api.Models;
using DataCentre.Api.PreProcess;
using DataCentre.Api.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MySqlConnector;
using Newtonsoft.Json;
using System.Data;
using System.Data.Common;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/data")]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    public class PermissionController : BaseController
    {
        public PermissionController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper, IConfiguration iConfig) : base(Logger, RepositoryWrapper, iConfig)
        {

        }
        [HttpGet]
        public ApiResult<ResultView> Get(int id)
        {
            ApiResult<ResultView> apiResult = new ApiResult<ResultView>(_localizer.GetValue<string>("AppSettings:localize"));
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
                    IDbCommand cmd = conn.CreateCommand();
                    string delCmd = "DELETE FROM UserPrivileges WHERE PrivilegeGroup=@PrivilegeGroup";
                    cmd.CommandText = delCmd;
                    cmd.Parameters.Add(new MySqlParameter("@PrivilegeGroup", Login.PrivilegeGroup));
                    delCmd += ", @PrivilegeGroup="+ Login.PrivilegeGroup;
                    _logger.LogInfo(delCmd);
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                    foreach(int ids in data.idList)
                    {
                        cmd = conn.CreateCommand();
                        delCmd = "INSERT INTO UserPrivileges (PrivilegeGroup, PrivilegeId) VALUES(@PrivilegeGroup, @PrivilegeId)";
                        cmd.CommandText = delCmd;
                        cmd.Parameters.Add(new MySqlParameter("@PrivilegeGroup", Login.PrivilegeGroup));
                        cmd.Parameters.Add(new MySqlParameter("@PrivilegeId", ids));
                        delCmd += ", @PrivilegeGroup=" + Login.PrivilegeGroup;
                        delCmd += ", @PrivilegeId=" + ids;
                        _logger.LogInfo(delCmd);
                        cmd.Transaction = tran;
                        cmd.ExecuteNonQuery();
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
