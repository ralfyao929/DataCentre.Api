using Dapper;

namespace DataCentre.Api.Entity.Models.Product
{
    /// <summary>
    /// 請求異動產品資料
    /// </summary>
    [Table("ProductReview")]
    public class ProductReview
    {
        /// <summary>
        /// 資料PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 元產品ID
        /// </summary>
        [Column("pr_product_id")]
        public int ProductId { get; set; }
        /// <summary>
        /// 產品別ID
        /// </summary>
        [Column("p_product_type_id")]
        public int? productTypeId { get; set; }
        /// <summary>
        /// 產品細項總稱
        /// </summary>
        [Column("p_product_general_name")]
        public string productName1 { get; set; }
        /// <summary>
        /// 產品細項
        /// </summary>
        [Column("p_product_detail_name")]
        public string productName2 { get; set; }
        /// <summary>
        /// 產品類ID
        /// </summary>
        [Column("p_product_class_id")]
        public int? productClassId { get; set; }
        [IgnoreInsert]
        [IgnoreSelect]
        [IgnoreUpdate]
        /// <summary>
        /// 隸屬公司ID Array，建立多筆審核資料使用，不Mapping到DB
        /// </summary>
        public string companyIdArr { get; set; }
        /// <summary>
        /// 隸屬公司ID
        /// </summary>
        [Column("p_belongto_company_id")]
        public int companyId { get; set; }
        /// <summary>
        /// 供應商ID
        /// </summary>
        [Column("p_supplier_id")]
        public int? supplierName { get; set; }
        /// <summary>
        /// 負責人ID
        /// </summary>
        [Column("p_responser_id")]
        public int? personInChargeId { get; set; }
        /// <summary>
        /// 負責單位
        /// </summary>
        [Column("p_responser_dept")]
        public int? departmentId { get; set; }
        /// <summary>
        /// 是否列入成本
        /// </summary>
        [Column("p_is_cost")]
        public int? isSetCost { get; set; }
        /// <summary>
        /// 會計科目id
        /// </summary>
        [Column("p_account")]
        public int? accounting { get; set; }
        /// <summary>
        /// 會計子科目id
        /// </summary>
        [Column("p_account_sub")]
        public int? accountingBranch { get; set; }
        /// <summary>
        /// 會計產品別id
        /// </summary>
        [Column("p_account_prod")]
        public int? accountingProductType { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("p_creator")]
        public string createUser { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("p_create_date")]
        public DateTime createdTime { get; set; }
        /// <summary>
        /// 審核狀態
        /// </summary>
        [Column("p_review_status")]
        public int reviewStatus { get; set; }
        /// <summary>
        /// 請求類型
        /// </summary>
        [Column("p_review_request_type")]
        public int requestType { get; set; }
        /// <summary>
        /// 退回原因
        /// </summary>
        [Column("p_drawback_reason")]
        public string DrawBackReason { get; set; }
        /// <summary>
        /// 審核人員
        /// </summary>
        [Column("p_reviewer")]
        public string reviewer { get; set; }
        /// <summary>
        /// 審核日期
        /// </summary>
        [Column("p_review_date")]
        public DateTime reviewDate { get; set; }
    }
}
