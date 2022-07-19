using DataCentre.Api.Controllers;
using Microsoft.Extensions.Localization;

namespace DataCentre.Api.Models
{
    public class ApiResult<T>
    {
        private string _message = "";
        private string _lang = "";
        private ResponseCode _responseCode = null;//;new ResponseCode(_lang);
        private IStringLocalizer<Localize.Resources> _localizer;
        public ApiResult(IStringLocalizer<Localize.Resources> Localizer)
        {
            _localizer = Localizer;
        }
        public ApiResult(string Lang = "zh-TW")
        {
            _lang = Lang;
            _responseCode = new ResponseCode(Lang);
        }
        public string Code { get; set; } = "";
        public string Message
        {
            get { return _responseCode.GetCodeMessage(this.Code, _message, _localizer); }
            set { _message = value; }
        }
        public T? Result { get; set; }
    }
}
