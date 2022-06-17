using Dapper;

namespace DataCentre.Api.Entity.Models.Cloud
{
    /// <summary>
    /// 雲端帳號管理審核資料表
    /// </summary>
    [Table("CloudAccountManageReview")]
    public class CloudAccountManageReview
    {
        /// <summary>
        /// 雲端帳號管理維護審核ID
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 原雲端帳號審核ID
        /// </summary>
        [Column("camr_original_id")]
        public int OriginalId { get; set; }
        /// <summary>
        /// 所屬公司ID
        /// </summary>
        [Column("camr_company_id")]
        public int CompanyId { get; set; }
        /// <summary>
        /// 客戶ID
        /// </summary>
        [Column("camr_customer_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 整批折扣金額
        /// </summary>
        [Column("camr_whole_discount_price")]
        public decimal WholeDiscountPrice { get; set; }
        /// <summary>
        /// 是否整單優惠
        /// </summary>
        [Column("camr_is_whole_premium")]
        public int IsWholePremium { get; set; }
        /// <summary>
        /// 整單服務費
        /// </summary>
        [Column("camr_whole_service_fee")]
        public decimal WholeServiceFee { get; set; }
        /// <summary>
        /// 整單帳號額度
        /// </summary>
        [Column("camr_whole_account_credit")]
        public decimal WholeAccountCredit { get; set; }
        /// <summary>
        /// 整單折扣趴數
        /// </summary>
        [Column("camr_whole_discount_percent")]
        public decimal WholeDiscountPercent { get; set; }
        /// <summary>
        /// 整單滿額優惠
        /// </summary>
        [Column("camr_whole_full_premium")]
        public decimal WholeFullPremium { get; set; }
        /// <summary>
        /// 產品資料ID
        /// </summary>
        [Column("camr_product_id")]
        public int ProductId { get; set; }
        /// <summary>
        /// 專案名稱
        /// </summary>
        [Column("camr_project_id")]
        public string ProjectName { get; set; }
        /// <summary>
        /// 需要技術支援
        /// </summary>
        [Column("camr_need_tech_support")]
        public string NeedTechSupport { get; set; }
        /// <summary>
        /// 審核狀態
        /// </summary>
        [Column("camr_review_status")]
        public int ReviewStatus { get; set; }
        /// <summary>
        /// 審核回饋
        /// </summary>
        [Column("camr_review_comment")]
        public string ReviewComment { get; set; }
        /// <summary>
        /// 請求類型
        /// </summary>
        [Column("camr_request_type")]
        public int RequestType { get; set; }
        /// <summary>
        /// 審核人員
        /// </summary>
        [Column("camr_reviewer")]
        public string Reviewer { get; set; }
        /// <summary>
        /// 審核日期
        /// </summary>
        [Column("camr_review_date")]
        public DateTime? ReviewDate { get; set; }
        /// <summary>
        /// 雲端帳號審核列表
        /// </summary>
        [IgnoreInsert]
        [IgnoreSelect]
        [IgnoreUpdate]
        public List<CloudAccountReview> CloudAccountReview { get; set; }
    }
    /// <summary>
    /// 雲端帳號審核
    /// </summary>
    [Table("CloudAccountReview")]
    public class CloudAccountReview
    {
        /// <summary>
        /// 雲端帳號審核ID
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 原雲端帳號id
        /// </summary>
        [Column("car_original_account_id")]
        public int OriginalAccountId { get; set; }
        /// <summary>
        /// 交易幣別ID
        /// </summary>
        [Column("car_currency_id")]
        public int CurrencyId { get; set; }
        /// <summary>
        /// 計費項目
        /// </summary>
        [Column("car_charge_item")]
        public string ChargeItem { get; set; }
        /// <summary>
        /// 服務項目
        /// </summary>
        [Column("car_service_item")]
        public string ServiceItem { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        [Column("car_account_id")]
        public string AccountId { get; set; }
        /// <summary>
        /// 測試帳號
        /// </summary>
        [Column("car_test_account_id")]
        public string TestAccountId { get; set; }
        /// <summary>
        /// 帳號額度
        /// </summary>
        [Column("car_account_credit")]
        public decimal AccountCredit { get; set; }
        /// <summary>
        /// 滿額優惠值
        /// </summary>
        [Column("car_full_premium")]
        public decimal FullPremium { get; set; }
        /// <summary>
        /// 測試到期日
        /// </summary>
        [Column("car_test_due_date")]
        public DateTime? TestDueDate { get; set; }
        /// <summary>
        /// 服務費趴數
        /// </summary>
        [Column("car_servicefee_discount_percent")]
        public decimal ServiceFeeDiscountPercent { get; set; }
        /// <summary>
        /// 折扣趴數
        /// </summary>
        [Column("car_discount_percent")]
        public decimal DiscountPercent { get; set; }
        /// <summary>
        /// 折扣金額
        /// </summary>
        [Column("car_discount_price")]
        public decimal DiscountPrice { get; set; }
        /// <summary>
        /// 移轉其他客戶ID
        /// </summary>
        [Column("car_transfer_customer_id")]
        public int TransferOtherCustomerId { get; set; }
        /// <summary>
        /// PM備註
        /// </summary>
        [Column("car_pm_comment")]
        public string PMComment { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [Column("car_comment")]
        public string Comment { get; set; }
        /// <summary>
        /// 帳號號碼
        /// </summary>
        [Column("car_account_number")]
        public int AccountNumber { get; set; }
        /// <summary>
        /// 帳號啟用日期
        /// </summary>
        [Column("car_active_date")]
        public DateTime? ActiveDate { get; set; }
        /// <summary>
        /// 是否為代金劵
        /// </summary>
        [Column("car_is_coupon")]
        public int IsCoupon { get; set; }
        /// <summary>
        /// 雲端帳號管理ID
        /// </summary>
        [Column("car_cloud_account_manage_id")]
        public int CloudAccountManageId { get; set; }
    }
}
