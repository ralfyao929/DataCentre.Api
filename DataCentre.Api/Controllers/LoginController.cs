using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models;
using DataCentre.Api.Models.Authentication;
using DataCentre.Api.PreProcess;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    public class LoginController : BaseController
    {
        
        public LoginController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IConfiguration iConfig) : base(logger, repositoryWrapper, iConfig)
        {
            
        }
        [HttpPost]
        public ApiResult<LoginDataView> Post(LoginData name)
        {
            //產生回傳訊息物件(這部分使否統一在BaseController實作?)
			ApiResult<LoginDataView> apiResult = new ApiResult<LoginDataView>(_localizer.GetValue<string>("AppSettings:localize"));
            _logger.LogInfo("login user name:"+name.Username+", password:"+name.Password);
            RequestBody = JsonConvert.SerializeObject(name);
            List<UserBase> logins = _repositoryWrapper.LoginData.FindByCondition(new { UserBaseNo = name.Username, UserBasePwd = name.Password }).ToList();
            if (logins.Count() > 0)
            {
                _logger.LogInfo("has data");
                // Get Token
                LoginDataView loginView = new LoginDataView();
                loginView.loginData = (UserBase)logins.ToList()[0];
                loginView.Token = GetToken(loginView.loginData, _repositoryWrapper);
                apiResult.Code = "0000";
                apiResult.Result = loginView;
                // Backend write APILog information
                LogAPI log = new LogAPI();
                log.LogAPIUrl = UriHelper.GetDisplayUrl(Request);
                log.LogAPIMethod = Request.Method;
                log.LogAPIInputData = JsonConvert.SerializeObject(name);
                log.LogAPIResponeCode = Response.StatusCode.ToString();
                log.LogAPIOuptData = JsonConvert.SerializeObject(apiResult);
                log.LogAPICallUser = name.Username;
                log.createdTime = DateTime.Now;
                _repositoryWrapper.APILog.Create(log);
                //ResponseBody = JsonConvert.SerializeObject(apiResult);
                return apiResult;
            }
            else
            {
                // 找不到相對應的userID，可能為密碼或帳號錯誤
                apiResult.Code = "1002";
                return apiResult;
            }
            apiResult.Code = "1001";
            return apiResult;
        }
        
        private Token GetToken(UserBase User, IRepositoryWrapper RepositoryWrapper)
        {

            Token token = Token.Create(User, RepositoryWrapper);
            return token;
        }
    }
}
