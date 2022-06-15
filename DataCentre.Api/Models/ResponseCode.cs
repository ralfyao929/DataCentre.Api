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
            // 1=用戶相關出現問題.
            { "1001", "Token無效或是過期" },
            { "1003", "沒有權限取得相關資訊"},
            { "1011", "沒有權限設定月結相關功能" },
            { "1012", "沒有權限進行月結2與月結鎖定" },
            { "1013", "沒有權限進行月結相關權限，因此不能刪除訂單裡面的產品" },
            // 2=帶入的資料不符合規定.
            { "2010", "目前公司還不能月結鎖定，可能目前月結狀態還不是月結2確認" },
            { "2011", "目前公司還不能月結2確認，可能目前月結狀態還不是月結1確認" },
            // 3=驗證類.
            { "3009", "儲存月結資料失敗，因為您修改了禁止修改的選項" },
            { "3011", "無法刪除該訂單的產品，因為該訂單已月結鎖定，或發票狀態非未開、列管、作廢重開" },
            // 4=資料遺失.
            { "4017", "找不到相對應的訂單id。" },
            // 9=系統錯誤
            { "9999", "未知的錯誤"},
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
