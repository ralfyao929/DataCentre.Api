using Dapper;

namespace DataCentre.Api.Entity.Models.Customer
{
    /// <summary>
    /// 請求客戶異動資料表
    /// </summary>
    [Table("CustomerReview")]
    public class CustomerReview
    {
        /// <summary>
        /// 審核ID
        /// </summary>
        [Column("cr_id")]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 負責公司清單
        /// foreign key欄位，對應到CusToCompany Table.id
        /// </summary>
        [Column("cr_ctcid_id")]
        public string BelongToCompanyId { get; set; }
        /// <summary>
        /// 客戶別
        /// </summary>
        [Column("cr_identity_name")]
        public string IdentityName { get; set; }
        /// <summary>
        /// 統一編號
        /// </summary>
        [Column("cr_unify_number")]
        public string UnifyNumber { get; set; }
        /// <summary>
        /// 公司抬頭
        /// </summary>
        [Column("cr_company_name")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 客戶簡稱
        /// </summary>
        [Column("cr_customer_alias")]
        public string CustomerAlias { get; set; }
        /// <summary>
        /// 客戶類別
        /// </summary>
        [Column("cr_customer_class")]
        public int CustomerClass { get; set; }
        /// <summary>
        /// 客戶產業
        /// </summary>
        [Column("cr_customer_industry")]
        public int CustomerIndustry { get; set; }
        /// <summary>
        /// 隸屬國家
        /// </summary>
        [Column("cr_country")]
        public int Country { get; set; }
        /// <summary>
        /// 交易幣別
        /// </summary>
        [Column("cr_currency")]
        public int Currency { get; set; }
        /// <summary>
        /// 發票類別
        /// </summary>
        [Column("cr_invoice_type")]
        public string InvoceType { get; set; }
        /// <summary>
        /// 負責業務ID
        /// </summary>
        [Column("cr_sales_id")]
        public int SalesId { get; set; }
        /// <summary>
        /// 業務單位ID
        /// </summary>
        [Column("cr_business_unit_id")]
        public string BusinessUnitId { get; set; }
        /// <summary>
        /// 請求異動客戶業務聯絡人資料
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<CustomerContactReview> CustomerContactReviews { get; set; }
        /// <summary>
        /// 請求異動客戶帳戶聯絡人資料
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<CustomerAccountReview> CustomerAccountReviews { get; set; }
        /// <summary>
        /// 審核狀態
        /// </summary>
        [Column("cr_review_status")]
        public int ReviewStatus { get; set; }
        /// <summary>
        /// 退回原因
        /// </summary>
        [Column("cr_drawback_reason")]
        public string? DrawBackReason { get; set; }
        /// <summary>
        /// 付款條件ID
        /// </summary>
        [Column("cr_payment_term")]
        public int PaymentTerm { get; set; }
        /// <summary>
        /// 是否為ICP客戶
        /// </summary>
        [Column("cr_is_icp")]
        public int IsICP { get; set; }
        /// <summary>
        /// 請求類型
        /// </summary>
        [Column("cr_request_type")]
        public int RequestType { get; set; }
        /// <summary>
        /// 銷帳帳號
        /// </summary>
        [Column("cr_bank_account")]
        public string? BankAccount { get; set; }
        /// <summary>
        /// 是否為預付型客戶
        /// </summary>
        [Column("cr_is_prepaid")]
        public int IsPrepaid { get; set; }
        /// <summary>
        /// 請求異動匯款銀行資料
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<CustomerBankReview> CustomerBankReviews { get; set; }
        /// <summary>
        /// 審核者
        /// </summary>
        [Column("cr_reviewer")]
        public string Reviewer { get; set; }
        /// <summary>
        /// 對帳單密碼是否與統編相同
        /// </summary>
        [Column("cr_bank_statement_pw_equal_unifyno")]
        public int IsBankStatementPwEqualUnifyNo { get; set; }
        /// <summary>
        /// 是否寄送對帳單
        /// </summary>
        [Column("cr_is_mail_bank_statement")]
        public int IsMailBankStatement { get; set; }
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<CustomerCompanyReview> CustomerCompanies { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("cr_created_time")]
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("cr_creator")]
        public string Creator { get; set; }
    }
    /// <summary>
    /// 請求異動客戶業務聯絡人資料
    /// </summary>
    [Table("CustomerContactReview")]
    public class CustomerContactReview
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("ccr_id")]
        public int id { get; set; }
        /// <summary>
        /// 請求客戶異動資料ID
        /// </summary>
        [Column("ccr_customer_review_id")]
        public int CustomerReviewId { get; set; }
        /// <summary>
        /// 業務名稱
        /// </summary>
        [Column("ccr_sales_name")]
        public string SalesName { get; set; }
        /// <summary>
        /// 業務電話
        /// </summary>
        [Column("ccr_sales_tel")]
        public string SalesTel { get; set; }
        /// <summary>
        /// 業務email
        /// </summary>
        [Column("ccr_sales_email")]
        public string SalesEmail { get; set; }
    }
    /// <summary>
    /// 請求異動客戶帳務聯絡人資料
    /// </summary>
    [Table("CustomerAccountReview")]
    public class CustomerAccountReview
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("car_id")]
        public int id { get; set; }
        /// <summary>
        /// 請求客戶異動資料ID
        /// </summary>
        [Column("car_customer_review_id")]
        public int CustomerReviewId { get; set; }
        /// <summary>
        /// 帳務聯絡人名稱
        /// </summary>
        [Column("car_accountant_name")]
        public string AccountantName { get; set; }
        /// <summary>
        /// 帳務聯絡人電話
        /// </summary>
        [Column("car_accountant_tel")]
        public string AccountantTel { get; set; }
        /// <summary>
        /// 帳務聯絡人email
        /// </summary>
        [Column("car_accountant_email")]
        public string AccountantEmail { get; set; }
    }
    /// <summary>
    /// 請求異動匯款銀行資料
    /// </summary>
    [Table("CustomerBankReview")]
    public class CustomerBankReview 
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("cbr_id")]
        public int id { get; set; }
        /// <summary>
        /// 請求異動客戶資料ID
        /// </summary>
        [Column("cbr_customer_review_id")]
        public int CustomerReviewId { get; set; }
        /// <summary>
        /// 匯款帳號
        /// </summary>
        [Column("cbr_bank_account")]
        public string BankAccount { get; set; }
        /// <summary>
        /// 匯款銀行名稱
        /// </summary>
        [Column("cbr_bank_name")]
        public string BankName { get; set; }
        /// <summary>
        /// 分行名
        /// </summary>
        [Column("cbr_branch_name")]
        public string BranchName { get; set; }
        /// <summary>
        /// 請求異動匯款銀行帳號資料允許幣別
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<CustomerBankCurrencyReview> CustomerBankCurrencyReviews { get; set; }
    }
    /// <summary>
    /// 請求異動匯款銀行允許幣別資料
    /// </summary>
    [Table("CustomerBankCurrencyReview")]
    public class CustomerBankCurrencyReview 
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("cbcr_id")]
        public int id { get; set; }
        /// <summary>
        /// 請求異動客戶資料ID
        /// </summary>
        [Column("cbcr_customer_review_id")]
        public int CustomerReviewId { get; set; }
        /// <summary>
        /// 幣別ID
        /// </summary>
        [Column("cbcr_currency_id")]
        public int CurrencyId { get; set; }
    }
    /// <summary>
    /// 請求異動客戶資料隸屬公司
    /// </summary>
    [Table("CustomerCompanyReview")]
    public class CustomerCompanyReview
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("cbc_id")]
        public int id { get; set; }
        /// <summary>
        /// 請求異動客戶資料ID
        /// </summary>
        [Column("cbc_customer_company_review_id")]
        public int CustomerCompanyReviewId { get; set; }
        /// <summary>
        /// 我的公司ID
        /// </summary>
        [Column("cbc_customer_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 客戶ID
        /// </summary>
        [Column("cbc_company_id")]
        public int CompanyId { get; set; }
    }
}
