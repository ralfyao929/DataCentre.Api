using DataCentre.Api.Entity.Models;
using Newtonsoft.Json;
using System.Text;

namespace DataCentre.Api.Models.Authentication
{
    public class Token
    {
        //Token
        public string access_token { get; set; }
        //Refresh Token
        public string refresh_token { get; set; }
        //幾秒過期
        public int expires_in { get; set; }
        //產生 Token
        public static Token Create(string user)
        {
            var exp = 3600;   //過期時間(秒)

            //稍微修改 Payload 將使用者資訊和過期時間分開
            var payload = new Payload<string>
            {
                info = user,
                //Unix 時間戳
                exp = Convert.ToInt32(
                    (DateTime.Now.AddSeconds(exp) -
                     new DateTime(1970, 1, 1)).TotalSeconds)
            };

            var json = JsonConvert.SerializeObject(payload);
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            var iv = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16);

            //使用 AES 加密 Payload
            var encrypt = Utility.Utility
                .AESEncrypt(base64, Utility.Utility.key.Substring(0, 16), iv);

            //取得簽章
            var signature = Utility.Utility
                .ComputeHMACSHA256(iv + "." + encrypt, Utility.Utility.key.Substring(0, 36));

            return new Token
            {
                //Token 為 iv + encrypt + signature，並用 . 串聯
                access_token = iv + "." + encrypt + "." + signature,
                //Refresh Token 使用 Guid 產生
                refresh_token = Guid.NewGuid().ToString().Replace("-", ""),
                expires_in = exp,
            };
        }
        public string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
