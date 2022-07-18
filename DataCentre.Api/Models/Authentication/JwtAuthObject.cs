using DataCentre.Api.Entity.Models;

namespace DataCentre.Api.Models.Authentication
{
    public class JwtAuthObject
    {
        public JwtAuthObject()
        {
        }

        public int Id { get; set; }
        public string No { get; set; }
        public string Name { get; set; }
        public DateTime exp { get; set; }
        public List<UserPrivilege> PrivilegeList { get; set; }
    }
}