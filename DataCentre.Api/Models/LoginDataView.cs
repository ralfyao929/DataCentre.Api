using DataCentre.Api.Entity.Models;
using DataCentre.Api.Models.Authentication;

namespace DataCentre.Api.Models
{
    public class LoginDataView
    {
        public LoginData loginData { get; set; }
        public Token Token { get; set; }
    }
}
