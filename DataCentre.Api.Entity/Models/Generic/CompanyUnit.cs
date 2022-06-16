using Dapper;

namespace DataCentre.Api.Entity.Models.Generic
{
    /// <summary>
    /// 公司單位
    /// </summary>
    [Table("CompanyUnit")]
    public class CompanyUnit
    {
        /// <summary>
        /// 公司單位ID
        /// </summary>
        [Key]
        [Column("cu_id")]
        public int ID { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        [Column("cu_name")]
        public string Name { get; set; }
        /// <summary>
        /// 部門代號
        /// </summary>
        [Column("cu_dept_id")]
        public string DeptId { get; set; }
        /// <summary>
        /// 建立日期時間
        /// </summary>
        [Column("cu_created_time")]
        public DateTime CreatedTime { get; set; }
    }
}
