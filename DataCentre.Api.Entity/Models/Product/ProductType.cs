using Dapper;

namespace DataCentre.Api.Entity.Models.Product
{
    /// <summary>
    /// 產品類
    /// </summary>
    [Table("ProductType")]
    public class ProductType
    {
        /// <summary>
        /// PK
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 產品類ID
        /// </summary>
        [Column("pt_id")]
        public int ProductTypeId { get; set; }
        /// <summary>
        /// 產品類名稱
        /// </summary>
        [Column("pt_name")]
        public string ProductTypeName { get; set; }
        /// <summary>
        /// 發票名稱
        /// </summary>
        [Column("pt_invoice_name")]
        public string InvoiceName { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("pt_create_date")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("pt_creator")]
        public string Creator { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [Column("pt_modify_date")]
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("pt_modify_user")]
        public string Modifier { get; set; }
    }
}
