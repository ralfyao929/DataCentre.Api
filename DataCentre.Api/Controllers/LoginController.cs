using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models;
using DataCentre.Api.Models.Authentication;
using DataCentre.Api.PreProcess;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
//using DataCentre.Api.Utility;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    public class LoginController : BaseController
    {
        
        public LoginController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper) : base(logger, repositoryWrapper)
        {
            
        }
        [HttpPost]
        public ApiResult<LoginDataView> Post(LoginData name)
        {
			ApiResult<LoginDataView> apiResult = new ApiResult<LoginDataView>();
            _logger.LogInfo("login user name:"+name.Username+", password:"+name.Password);
            //this.Request
            //this.Url
            RequestBody = JsonConvert.SerializeObject(name);
            List<LoginData> logins = _repositoryWrapper.LoginData.FindByCondition(new { Username = name.Username, Password = name.Password }).ToList();
            // 直接從EF Set<T>()查資料，LINQ 做 JOIN.
            // JOIN欄位判斷 一定要 'equals'，不可以使用'=='.
            // 以下的LINQ等同於下列SQL:
            // SELECT `l`.`CreateDate`, `l`.`CreateUser`, `l`.`Password`, `l`.`PrivilegeGroup`,
            // `l`.`Username`, `u`.`PrivilegeGroup`, `u`.`PrivilegeId`, `u`.`CreateDate`
            // FROM `LoginData` AS `l`
            // INNER JOIN `UserPrivileges` AS `u` ON `l`.`PrivilegeGroup` = `u`.`PrivilegeGroup`
            // WHERE `l`.`Username` = '{name.Username}'

            // 取得DbSet Table做Join查詢.
            //RepositoryContext context = _repositoryWrapper.GetRepositoryContext();
            // 實際查詢資料.
            //var queryResult = from user in context.Set<LoginData>()
            //                  join privilege in context.Set<UserPrivilege>()
            //                  on user.PrivilegeGroup equals privilege.PrivilegeGroup into Grouping
            //                  where user.Username == name.Username
            //                  select new { user.Username, Grouping };
            if (logins.Count() > 0)
            {
                _logger.LogInfo("has data");
                LoginDataView loginView = new LoginDataView();
                loginView.loginData = (LoginData)logins.ToList()[0];
                loginView.Token = GetToken(loginView.loginData, _repositoryWrapper);
                //string responseStr = Utility.Utility.GetSuccessJsonStr("'data':" + JsonConvert.SerializeObject(loginView));
				apiResult.Code = "0000";
                apiResult.Result = loginView;
                APILog log = new APILog();
                log.APIUrl = UriHelper.GetDisplayUrl(Request);
                log.Method = Request.Method;
                log.RequestJson = JsonConvert.SerializeObject(name);
                log.ResponseCode = Response.StatusCode.ToString();
                log.ResponseJson = JsonConvert.SerializeObject(apiResult);
                log.User = name.Username;
                log.CreatedTime = DateTime.Now;
                _repositoryWrapper.APILog.Create(log);
                ResponseBody = JsonConvert.SerializeObject(apiResult);
                return apiResult;
            }
            apiResult.Code = "1001";
            return apiResult;
        }
        
        private Token GetToken(LoginData User, IRepositoryWrapper RepositoryWrapper)
        {

            Token token = Token.Create(User, RepositoryWrapper);
            return token;
        }
    }
}
