using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models.Generic
{
    [Table("Company")]
    public class Company
    {
        /// <summary>
        /// 我的公司ID
        /// </summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// 幣別設定
        /// </summary>
        [Column("currency")]
        public int Currency { get; set; }
        /// <summary>
        /// 建立日期時間
        /// </summary>
        [Column("created_time")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedTime { get; set; }
    }
}
