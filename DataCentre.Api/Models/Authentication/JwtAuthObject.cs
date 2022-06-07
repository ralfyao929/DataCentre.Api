using DataCentre.Api.Entity.Models;

namespace DataCentre.Api.Models.Authentication
{
    public class JwtAuthObject
    {
        public JwtAuthObject()
        {
        }

        public string Id { get; set; }
        public DateTime exp { get; set; }
        public List<UserPrivilege> PrivilegeList { get; set; }
    }
}