using Dapper;

namespace DataCentre.Api.Entity.Models.Generic
{
    /// <summary>
    /// 公司單位
    /// </summary>
    [Table("CompanyUnit")]
    public class CompanyUnit
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 公司單位ID
        /// </summary>
        [Column("cu_id")]
        public int ID { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [Column("cu_name")]
        public string Name { get; set; }
        /// <summary>
        /// 建立日期時間
        /// </summary>
        [Column("cu_create_time")]
        public DateTime CreatedTime { get; set; }
    }
}
