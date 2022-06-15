using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models
{
    [Table("PrivilegeData")]
    public class PrivilegeData
    {
        /// <summary>
        /// 資料PK
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("p_id")]
        public int Id { get; set; }
        /// <summary>
        /// 權限名稱
        /// </summary>
        [Column("p_privilege_name")]
        public string PrivilegeName { get; set; }
        /// <summary>
        /// 權限類型0:一般 1:報表 -1:超級管理者
        /// </summary>
        [Column("p_privilege_type")]
        public int PrivilegeType { get; set; }
        /// <summary>
        /// 權限網址，驗證是否有執行權限使用
        /// </summary>
        [Column("p_privilege_url")]
        public string PrivilegeUrl { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("p_create_time")]
        public DateTime CreatedTime { get; set; }
    }
}
