namespace DataCentre.Api.Models
{
    public class ApiResult<T>
    {
        private string _message = "";
        private ResponseCode _responseCode = new ResponseCode();

        public string Code { get; set; } = "";
        public string Message
        {
            get { return _responseCode.GetCodeMessage(this.Code, _message); }
            set { _message = value; }
        }
        public T? Result { get; set; }
    }
}
