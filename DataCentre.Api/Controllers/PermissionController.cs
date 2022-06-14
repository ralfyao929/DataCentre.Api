using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.PreProcess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public string Get(int id)
        {
            try
            {
                var privList = _repositoryWrapper.PrivilegeData.Query(@"SELECT a.p_id id, a.p_privilege_name name, a.p_privilege_type type, case when c.id is null then false else true end isHave FROM PrivilegeData a
                                                                        LEFT OUTER JOIN UserPrivileges b on a.p_id = b.PrivilegeId
                                                                        LEFT OUTER JOIN LoginData c on b.PrivilegeGroup = c.l_privilege_group and c.id=@id", new { id = id });
                return Utility.Utility.GetSuccessJsonStr("\"data\":" + JsonConvert.SerializeObject(privList));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                return Utility.Utility.GetFailJsonStr("9999", "系統發生錯誤，請洽系統管理人員");
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
