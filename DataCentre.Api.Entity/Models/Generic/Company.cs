using Dapper;

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
        public DateTime CreatedTime { get; set; }
    }
}
