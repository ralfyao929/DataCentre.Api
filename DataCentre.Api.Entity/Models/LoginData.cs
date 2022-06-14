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
        /// 資料表PK
        /// </summary>
        [Column("id")]
        [Key]
        public int id { get; set; }
        /// <summary>
        /// 使用者帳號
        /// </summary>
        [Required(ErrorMessage="User Name is required")]
        [Column("l_username")]
        public string Username { get; set; }
        /// <summary>
        /// 使用者密碼
        /// </summary>
        [Required(ErrorMessage ="Password is required")]
        [Column("l_password")]
        public string Password { get; set; }
        /// <summary>
        /// 所屬的權限列表，對應到 UserPrivilege
        /// </summary>
        [Column("l_privilege_group")]
        public string PrivilegeGroup { get; set; } = "";
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("l_create_date")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("l_create_user")]
        public string CreateUser { get; set; }

    }
}
