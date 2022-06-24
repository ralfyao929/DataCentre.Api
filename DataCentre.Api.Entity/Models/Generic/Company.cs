using Dapper;

namespace DataCentre.Api.Entity.Models.Generic
{
    [Table("Company")]
    public class Company
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 我的公司ID
        /// </summary>
        [Column("c_id")]
        public int ID { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        [Column("c_name")]
        public string Name { get; set; }
        /// <summary>
        /// 幣別設定
        /// </summary>
        [Column("c_currency_id")]
        public int Currency { get; set; }
        /// <summary>
        /// 建立日期時間
        /// </summary>
        [Column("c_create_time")]
        public DateTime CreatedTime { get; set; }
    }
}
