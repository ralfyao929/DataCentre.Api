namespace DataCentre.Api.Models.Authentication
{
    public class JwtAuthObject
    {
        public JwtAuthObject()
        {
        }

        public string Id { get; set; }
        public DateTime exp { get; set; }
    }
}