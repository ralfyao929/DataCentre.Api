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
using DataCentre.Api.Models;
using DataCentre.Api.View;

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
        public ApiResult<HomeView> Get()
        {
            //APILog log = new APILog();
            ApiResult<HomeView> apiResult = new ApiResult<HomeView>();
            try
            {
                string token = Request.Headers["Authorization"];
                JwtAuthObject jwtObject = Jose.JWT.Decode<JwtAuthObject>(
                            token,
                            Encoding.UTF8.GetBytes(Utility.Utility.key),
                            JwsAlgorithm.HS256);
                var privList = from privilegeList in jwtObject.PrivilegeList
                               join privilege in _repositoryWrapper.PrivilegeData.findAll() on privilegeList.PrivilegeId equals privilege.Id
                               select new { privilege.Id, privilege.PrivilegeName, privilege.PrivilegeType };
                HomeView HomeViews = new HomeView();
                HomeViews.data = privList;
                apiResult.Code = "0000";
                apiResult.Result = HomeViews;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                apiResult.Code = "9999";
                apiResult.Message = "未知的錯誤，請洽系統管理人員";
            }
            return apiResult;
        }
    }
}
