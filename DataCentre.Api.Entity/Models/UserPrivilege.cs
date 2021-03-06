using Dapper;

namespace DataCentre.Api.Entity.Models
{
    [Table("UserPrivileges")]
    public class UserPrivilege
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 權限的ID
        /// </summary>
        [Key]
        [Column("PrivilegeId")]
        public int PrivilegeId { get; set; }
        /// <summary>
        /// 所屬的權限
        /// </summary>
        [Key]
        [Column("PrivilegeGroup")]
        public string PrivilegeGroup { get; set; } = "";
        /// <summary>
        /// 權限的建立日期
        /// </summary>
        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }
    }
}
