using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models
{
    [Table("LoginData")]
    public class LoginData
    {
        /// <summary>
        /// 使用者帳號
        /// </summary>
        [Required(ErrorMessage="User Name is required")]
        [Key]
        [Column("Username")]
        public string Username { get; set; }
        /// <summary>
        /// 使用者密碼
        /// </summary>
        [Required(ErrorMessage ="Password is required")]
        [Column("Password")]
        public string Password { get; set; }
        /// <summary>
        /// 所屬的權限列表，對應到 UserPrivilege
        /// </summary>
        [Column("PrivilegeGroup")]
        public string PrivilegeGroup { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("CreateDate")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("CreateUser")]
        public string CreateUser { get; set; }

    }
}
