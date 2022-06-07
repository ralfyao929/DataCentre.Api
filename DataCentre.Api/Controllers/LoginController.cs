using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models;
using DataCentre.Api.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
//using DataCentre.Api.Utility;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        public LoginController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper) : base(logger, repositoryWrapper)
        {
            
        }
        [HttpPost]
        public string Post(LoginData name)
        {
            _logger.LogInfo("login user name:"+name.Username+", password:"+name.Password);
            List<LoginData> logins = _repositoryWrapper.LoginData.FindByCondition(l => l.Username == name.Username).ToList();
            
            if (logins.Count() > 0)
            {
                _logger.LogInfo("has data");
                LoginDataView loginView = new LoginDataView();
                loginView.loginData = (LoginData)logins.ToList()[0];
                loginView.Token = GetToken(loginView.loginData, _repositoryWrapper);
                return Utility.Utility.GetSuccessJsonStr(JsonConvert.SerializeObject(loginView));
            }
            return Utility.Utility.GetFailJsonStr("1001", "帳號或密碼錯誤");
        }
        
        private Token GetToken(LoginData User, IRepositoryWrapper RepositoryWrapper)
        {

            Token token = Token.Create(User, RepositoryWrapper);
            return token;
        }
    }
}
