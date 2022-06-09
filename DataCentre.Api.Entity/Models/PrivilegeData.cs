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
        [Column("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 權限名稱
        /// </summary>
        [Column("PrivilegeName")]
        public string PrivilegeName { get; set; }
        /// <summary>
        /// 權限類型0:一般 1:報表 -1:超級管理者
        /// </summary>
        [Column("PrivilegeType")]
        public int PrivilegeType { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("CreatedTime")]
        public DateTime CreatedTime { get; set; }
    }
}
