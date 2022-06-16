﻿using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Localize;
using DataCentre.Api.Models;
using DataCentre.Api.Models.Authentication;
using DataCentre.Api.PreProcess;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
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
        
        public LoginController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IConfiguration iConfig) : base(logger, repositoryWrapper, iConfig)
        {
            
        }
        [HttpPost]
        public ApiResult<LoginDataView> Post(LoginData name)
        {
			ApiResult<LoginDataView> apiResult = new ApiResult<LoginDataView>(_localizer.GetValue<string>("AppSettings:localize"));
            _logger.LogInfo("login user name:"+name.Username+", password:"+name.Password);
            RequestBody = JsonConvert.SerializeObject(name);
            List<LoginData> logins = _repositoryWrapper.LoginData.FindByCondition(new { Username = name.Username, Password = name.Password }).ToList();
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
