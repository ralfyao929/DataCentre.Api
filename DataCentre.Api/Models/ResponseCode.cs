namespace DataCentre.Api.Models
{
    public class ResponseCode
    {
        /*
         * 第一個字為分類
         * 0=成功
         * 1=用戶相關出現問題
         * 2=帶入的資料不符合規定
         * 3=驗證類
         * 4=資料遺失
         */

        Dictionary<string, string> responseCode = new Dictionary<string, string>()
        {
            { "0000", "成功" },
            { "1001", "Token無效或是過期" },
            { "9999", "未知的錯誤"}
        };

        public string GetCodeMessage(string code = "", string message = "")
        {
            if (true == (responseCode.ContainsKey(code)))
            {
                return responseCode[code];
            }
            else
            {   //自定義 message
                return message;
            }
        }
    }
}
