using DataCentre.Api.Contracts;
using DataCentre.Api.Entity.Models;
using DataCentre.Api.LoggerService;
using DataCentre.Api.Models;
using DataCentre.Api.Models.Authentication;
using DataCentre.Api.PreProcess;
using GoogleAuthenticatorService.Core;
using Microsoft.AspNetCore.Mvc;

namespace DataCentre.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ServiceFilter(typeof(JwtAuthActionFilter))]
    public class AuthenticateController : BaseController
    {
        private string AccountSecretKey { get; set; }
        public AuthenticateController(ILoggerManager Logger, IRepositoryWrapper RepositoryWrapper, IConfiguration iConfig) : base(Logger, RepositoryWrapper, iConfig)
        {
            //建立一把用戶的私鑰
            if (string.IsNullOrEmpty(AccountSecretKey))
            {
                AccountSecretKey = Guid.NewGuid().ToString("N").Substring(0, 10);
            }
        }
        /// <summary>
        /// 產生qrcode的內容與連結
        /// </summary>
        /// <param name="account">要產生qrcode的帳號</param>
        /// <returns>執行結果</returns>
        [HttpGet]
        public ApiResult<Models.Authentication.QrCode> getqrcode(string account)
        {
            Models.Authentication.QrCode QrCodeText = new Models.Authentication.QrCode();
            ApiResult<Models.Authentication.QrCode> apiResult = 
                new ApiResult<Models.Authentication.QrCode>(_localizer.GetValue<string>("AppSettings:localize"));
            var UserBaseList = _repositoryWrapper.LoginData.FindByCondition(new {UserBaseNo = account });
            UserBase user = new UserBase();
            if(UserBaseList.Count() > 0)
            {
                user = UserBaseList.ToList()[0];
            }
            try
            {
                if (!string.IsNullOrEmpty(user.UserBaseNo) && !string.IsNullOrEmpty(user.UserBasePwd))
                {
                    var tfa = new TwoFactorAuthenticator();
                    SetupCode setupInfo = tfa.GenerateSetupCode(account, $"{user.UserBaseNo}.{AES.AesEncrypt(user.UserBasePwd)}@digicentre.com", AccountSecretKey, 100, 100);
                    QrCodeText.QrCodeText = "<img src='" + setupInfo.QrCodeSetupImageUrl + "' />";
                    QrCodeText.QrCodeContent = "otpauth://totp/" + $"{user.UserBaseNo}.{AES.AesEncrypt(user.UserBasePwd)}@digicentre.com" + "?secret=" + setupInfo.ManualEntryKey + $"&issuer={user.UserBaseNo}.{AES.AesEncrypt(user.UserBasePwd)}";
                    apiResult.Result = QrCodeText;
                    apiResult.Code = "0000";
                }
                else
                {
                    apiResult.Code = "1002";
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex + ex.StackTrace);
                apiResult.Code = "9999";
            }
            return apiResult;
        }
    }
}
