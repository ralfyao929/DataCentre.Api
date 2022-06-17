using Dapper;

namespace DataCentre.Api.Entity.Models.Supplier
{
    /// <summary>
    /// 請求異動供應商資料
    /// </summary>
    [Table("SupplierReview")]
    public class SupplierReview
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 負責PM ID
        /// </summary>
        [Column("sr_response_pm_id")]
        public int ResponsePMId { get; set; }
        /// <summary>
        /// 月結天數ID
        /// </summary>
        [Column("sr_monthly_settlement_id")]
        public int MonthlySettlementDaysId { get; set; }
        /// <summary>
        /// 負責公司單位ID
        /// </summary>
        [Column("sr_response_bu_id")]
        public int ResponseBUId { get; set; }
        /// <summary>
        /// 供應商抬頭
        /// </summary>
        [Column("sr_supplier_title")]
        public string SupplierTitle { get; set; }
        /// <summary>
        /// 廠商名稱
        /// </summary>
        [Column("sr_supplier_name")]
        public string SupplierName { get; set; }
        /// <summary>
        /// 審核者
        /// </summary>
        [Column("sr_reviewer")]
        public string Reviewer { get; set; }
        /// <summary>
        /// 請求類型
        /// </summary>
        [Column("sr_request_type")]
        public int RequestType { get; set; }
        /// <summary>
        /// 審核狀態
        /// </summary>
        [Column("sr_review_status")]
        public string ReviewStatus { get; set; }
        /// <summary>
        /// 退回原因
        /// </summary>
        [Column("sr_drawback_reason")]
        public string DrawbackReason { get; set; }
        /// <summary>
        /// 統一編號
        /// </summary>
        [Column("sr_uni_number")]
        public int UnifiedNumber { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [Column("sr_comment")]
        public string Comment { get; set; }
        /// <summary>
        /// 原供應商資料的供應商名稱
        /// </summary>
        [Column("sr_original_name")]
        public string OriginalName { get; set; }
        /// <summary>
        /// 請求異動供應商資料隸屬公司列表
        /// </summary>
        [IgnoreInsert]
        [IgnoreSelect]
        [IgnoreUpdate]
        public List<SupplierCompanyReview> SupplierCompanyReviews { get; set; }
        /// <summary>
        /// 請求異動供應商聯絡人列表
        /// </summary>
        [IgnoreInsert]
        [IgnoreSelect]
        [IgnoreUpdate]
        public List<SupplierContactReview> SupplierContactReviews { get; set; }
    }
    /// <summary>
    /// 請求異動供應商隸屬公司
    /// </summary>
    [Table("SupplierCompanyReview")]
    public class SupplierCompanyReview 
    { 
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 請求異動供應商資料ID
        /// </summary>
        [Column("scr_sr_id")]
        public int SupplierReviewId { get; set; }
        /// <summary>
        /// 我的公司ID
        /// </summary>
        [Column("scr_company_id")]
        public int CompanyId { get; set; }
        /// <summary>
        /// 供應商資料ID
        /// </summary>
        [Column("scr_supplier_id")]
        public int SupplierId { get; set; }
    }
    /// <summary>
    /// 請求異動供應商聯絡人
    /// </summary>
    [Table("SupplierContactReview")]
    public class SupplierContactReview 
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 請求異動供應商資料ID
        /// </summary>
        [Column("scr1_sr_id")]
        public int SupplierReviewId { get; set; }
        /// <summary>
        /// 聯絡人姓名
        /// </summary>
        [Column("scr1_contact_name")]
        public string ContactName { get; set; }
        /// <summary>
        /// 聯絡人電話
        /// </summary>
        [Column("scr1_contact_tel")]
        public string ContactTel { get; set; }
        /// <summary>
        /// 聯絡人信箱
        /// </summary>
        [Column("scr1_contact_email")]
        public string ContactEmail { get; set; }
    }
    /// <summary>
    /// 請求異動供應商匯款銀行資料
    /// </summary>
    [Table("SupplierBankReview")]
    public class SupplierBankReview 
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 請求異動供應商資料ID
        /// </summary>
        [Column("sbr_sr_id")]
        public int SupplierReviewId { get; set; }
        /// <summary>
        /// 銀行名稱
        /// </summary>
        [Column("sbr_bank_name")]
        public string BankName { get; set; } 
        /// <summary>
        /// 匯款帳號
        /// </summary>
        [Column("sbr_bank_account")]
        public string BankAccount { get; set; }
        /// <summary>
        /// 分行名稱
        /// </summary>
        [Column("sbr_branch_name")]
        public string BranchName { get; set; }
    }
    /// <summary>
    /// 請求異動供應商銀行幣別資料
    /// </summary>
    [Table("SupplierCurrencyReview")]
    public class SupplierCurrencyReview 
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 請求異動供應商銀行資料id
        /// </summary>
        [Column("scr2_sbr_id")]
        public int SupplierBankReviewId { get; set; }
        /// <summary>
        /// 幣別ID
        /// </summary>
        [Column("scr2_currency_id")]
        public int CurrencyId { get; set; }
    }
}
