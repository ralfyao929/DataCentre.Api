using DataCentre.Api.Entity.Models;
using Jose;
using Newtonsoft.Json;
using System.Text;

namespace DataCentre.Api.Models.Authentication
{
    public class Token
    {
        public bool RESULT { get; set; }
        public string TOKEN { get; set; }
        //Token
        //public string access_token { get; set; }
        ////Refresh Token
        //public string refresh_token { get; set; }
        ////幾秒過期
        //public int expires_in { get; set; }
        //產生 Token
        public static Token Create(string user)
        {
            var exp = 1200;   //過期時間(秒)
            var payload = new JwtAuthObject()
            {
                Id = user,
                exp = DateTime.Now.AddSeconds(exp)
            };
            return new Token()
            {
                RESULT = true,
                TOKEN = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(Utility.Utility.key), JwsAlgorithm.HS256)
            };
        }
        
    }
}
