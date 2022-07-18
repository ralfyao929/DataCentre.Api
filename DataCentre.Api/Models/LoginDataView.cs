using DataCentre.Api.Entity.Models;
using DataCentre.Api.Models.Authentication;

namespace DataCentre.Api.Models
{
    public class LoginDataView
    {
        public UserBase loginData { get; set; }
        public Token Token { get; set; }
    }
}
