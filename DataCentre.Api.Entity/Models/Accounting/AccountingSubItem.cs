using Dapper;

namespace DataCentre.Api.Entity.Models.Accounting
{
    /// <summary>
    /// 會計子目
    /// </summary>
    [Table("AccountingSubItem")]
    public class AccountingSubItem
    {
        /// <summary>
        /// PK
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 會計子目ID
        /// </summary>
        [Column("asi_id")]
        public int AccountingSubItemId { get; set; }
        /// <summary>
        /// 會計子目
        /// </summary>
        [Column("asi_code")]
        public string AccountingSubItemCode { get; set; }
        /// <summary>
        /// 會計子目名稱
        /// </summary>
        [Column("asi_name")]
        public string AccountingSubItemName { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [Column("asi_created_time")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("asi_creator")]
        public DateTime? Creator { get; set; }
        /// <summary>
        /// 修改時間
        /// </summary>
        [Column("asi_modify_time")]
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("asi_modifor")]
        public DateTime? Modifier { get; set; }
    }
}
