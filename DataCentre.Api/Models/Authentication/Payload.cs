namespace DataCentre.Api.Models.Authentication
{
    public class Payload<T>
    {
        //使用者資訊
        public T info { get; set; }
        //過期時間
        public int exp { get; set; }
    }
}
