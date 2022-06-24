using Dapper;

namespace DataCentre.Api.Entity.Models.Accounting
{
    /// <summary>
    /// 會計科目
    /// </summary>
    [Table("AccountingProductType")]
    public class AccountingProductType
    {
        /// <summary>
        /// PK
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 會計產品別ID
        /// </summary>
        [Column("apt_id")]
        public int AccountingProductTypeId { get; set; }
        /// <summary>
        /// 會計產品別
        /// </summary>
        [Column("apt_code")]
        public string AccountingProductTypeCode { get; set; }
        /// <summary>
        /// 會計產品別名稱
        /// </summary>
        [Column("apt_name")]
        public string AccountingProductTypeName { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [Column("apt_created_time")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("apt_creator")]
        public string Creator { get; set; }
        /// <summary>
        /// 修改時間
        /// </summary>
        [Column("apt_modify_time")]
        public DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("apt_modifor")]
        public string Modifier { get; set; }
    }
}
