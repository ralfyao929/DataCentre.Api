using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models.Authentication;
using DataCentre.Api.PreProcess;
using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System.Text;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    [Route("api/[controller]/data")]
    public class HomeController : BaseController
    {
        public HomeController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper) : base(Logger, RepositoryWrapper)
        {
            
        }
        [HttpGet]
        public string Get()
        {
            APILog log = new APILog();
            try
            {
                string token = Request.Headers["Authorization"];
                JwtAuthObject jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                            token,
                            Encoding.UTF8.GetBytes(Utility.Utility.key),
                            JwsAlgorithm.HS256);
                DapperContext context = _repositoryWrapper.GetRepositoryContext();
                // Get Privilege List.
                var privList = from privilegeList in jwtObject.PrivilegeList
                               join privilege in _repositoryWrapper.PrivilegeData.findAll() on privilegeList.PrivilegeId equals privilege.Id
                               select new { privilege.Id, privilege.PrivilegeName, privilege.PrivilegeType };
                // Get Notify Json List.
                string notifyJson = "null";
                string responseJson = Utility.Utility.GetSuccessJsonStr("\"data\":" + JsonConvert.SerializeObject(privList.ToList()) + ",\"nofity\":" + notifyJson);
                log.APIUrl = UriHelper.GetDisplayUrl(Request);
                log.Method = "GET";
                log.RequestJson = String.Empty;
                log.ResponseCode = "200";
                log.ResponseJson = responseJson;
                log.User = jwtObject.Id;
                //log.CreatedTime = DateTime.Now;
                _repositoryWrapper.APILog.Create(log);
                _repositoryWrapper.Save();
                return responseJson;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                return Utility.Utility.GetFailJsonStr("9999", "系統發生錯誤，請洽系統管理人員");
            }
        }
    }
}
