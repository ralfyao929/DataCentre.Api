namespace DataCentre.Api.Utility
{
    public class Utility
    {
        public static string GetSuccessJsonStr(string data)
        {
            return "{'code':'0000','message':'Success','result':{'data':" + data + "}}";
        }
        public static string GetFailJsonStr(string code, string message)
        {
            return "{'code':'"+ code + "','message':'"+ message + "','result':null}";
        }
    }
}