using Dapper;

namespace DataCentre.Api.Entity.Models.Accounting
{
    /// <summary>
    /// 會計科目
    /// </summary>
    [Table("AccountingItem")]
    public class AccountingItem
    {
        /// <summary>
        /// PK
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 會計科目ID
        /// </summary>
        [Column("ai_id")]
        public int AccountingItemId { get; set; }
        /// <summary>
        /// 會計科目
        /// </summary>
        [Column("ai_code")]
        public string AccountingItemCode { get; set; }
        /// <summary>
        /// 會計科目名稱
        /// </summary>
        [Column("ai_name")]
        public string AccountingItemName { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [Column("ai_created_time")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("ai_creator")]
        public DateTime? Creator { get; set; }
        /// <summary>
        /// 修改時間
        /// </summary>
        [Column("ai_modify_time")]
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("ai_modifor")]
        public DateTime? Modifier { get; set; }
    }
}
