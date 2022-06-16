using Dapper;

namespace DataCentre.Api.Entity.Models.Customer
{
    /// <summary>
    /// 客戶資料表
    /// </summary>
    [Table("Customer")]
    public class Customer
    {
        /// <summary>
        /// 審核ID
        /// </summary>
        [Column("c_id")]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 負責公司ID
        /// </summary>
        [Column("c_company_id")]
        public int CompanyId { get; set; }
        /// <summary>
        /// 客戶別
        /// </summary>
        [Column("c_identity_name")]
        public string IdentityName { get; set; }
        /// <summary>
        /// 統一編號
        /// </summary>
        [Column("c_unify_number")]
        public string UnifyNumber { get; set; }
        /// <summary>
        /// 公司抬頭
        /// </summary>
        [Column("c_company_name")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 客戶簡稱
        /// </summary>
        [Column("c_customer_alias")]
        public string CustomerAlias { get; set; }
        /// <summary>
        /// 客戶類別
        /// </summary>
        [Column("c_customer_class")]
        public int CustomerClass { get; set; }
        /// <summary>
        /// 客戶產業
        /// </summary>
        [Column("c_customer_industry")]
        public int CustomerIndustry { get; set; }
        /// <summary>
        /// 隸屬國家
        /// </summary>
        [Column("c_country")]
        public int Country { get; set; }
        /// <summary>
        /// 交易幣別
        /// </summary>
        [Column("c_currency")]
        public int Currency { get; set; }
        /// <summary>
        /// 發票類別
        /// </summary>
        [Column("c_invoice_type")]
        public string InvoceType { get; set; }
        /// <summary>
        /// 負責業務ID
        /// </summary>
        [Column("c_sales_id")]
        public int SalesId { get; set; }
        /// <summary>
        /// 業務單位ID
        /// </summary>
        [Column("c_business_unit_id")]
        public string BusinessUnitId { get; set; }
        /// <summary>
        /// 客戶業務聯絡人資料
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<CustomerContact> CustomerContacts { get; set; }
        /// <summary>
        /// 客戶帳戶聯絡人資料
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<CustomerAccount> CustomerAccounts { get; set; }
        /// <summary>
        /// 付款條件ID
        /// </summary>
        [Column("c_payment_term")]
        public int PaymentTerm { get; set; }
        /// <summary>
        /// 是否為ICP客戶
        /// </summary>
        [Column("c_is_icp")]
        public int IsICP { get; set; }
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
        /// 匯款銀行資料
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<CustomerBank> CustomerBank { get; set; }
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
        /// <summary>
        /// 審核者
        /// </summary>
        [Column("cr_reviewer")]
        public string Reviewer { get; set; }
        /// <summary>
        /// 審核日期
        /// </summary>
        [Column("cr_review_time")]
        public DateTime ReviewTime { get; set; }
    }
    /// <summary>
    /// 客戶業務聯絡人資料
    /// </summary>
    [Table("CustomerContact")]
    public class CustomerContact
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("cc_id")]
        public int id { get; set; }
        /// <summary>
        /// 客戶ID
        /// </summary>
        [Column("cc_customer_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 業務名稱
        /// </summary>
        [Column("cc_sales_name")]
        public string SalesName { get; set; }
        /// <summary>
        /// 業務電話
        /// </summary>
        [Column("ccr_sales_tel")]
        public string SalesTel { get; set; }
        /// <summary>
        /// 業務email
        /// </summary>
        [Column("cc_sales_email")]
        public string SalesEmail { get; set; }
    }
    /// <summary>
    /// 客戶帳務聯絡人資料
    /// </summary>
    [Table("CustomerAccount")]
    public class CustomerAccount
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("ca_id")]
        public int id { get; set; }
        /// <summary>
        /// 客戶ID
        /// </summary>
        [Column("ca_customer_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 帳務聯絡人名稱
        /// </summary>
        [Column("ca_accountant_name")]
        public string AccountantName { get; set; }
        /// <summary>
        /// 帳務聯絡人電話
        /// </summary>
        [Column("ca_accountant_tel")]
        public string AccountantTel { get; set; }
        /// <summary>
        /// 帳務聯絡人email
        /// </summary>
        [Column("ca_accountant_email")]
        public string AccountantEmail { get; set; }
    }
    /// <summary>
    /// 匯款銀行資料
    /// </summary>
    [Table("CustomerBank")]
    public class CustomerBank
    {
        /// <summary>
        /// PK
        /// </summary>
        [Key]
        [Column("cb_id")]
        public int id { get; set; }
        /// <summary>
        /// 客戶ID
        /// </summary>
        [Column("cb_customer_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 匯款帳號
        /// </summary>
        [Column("cb_bank_account")]
        public string BankAccount { get; set; }
        /// <summary>
        /// 匯款銀行名稱
        /// </summary>
        [Column("cb_bank_name")]
        public string BankName { get; set; }
        /// <summary>
        /// 分行名
        /// </summary>
        [Column("cb_branch_name")]
        public string BranchName { get; set; }
        /// <summary>
        /// 匯款銀行帳號資料允許幣別列表
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<CustomerBankCurrency> CustomerBankCurrencys { get; set; }
    }
    /// <summary>
    /// 匯款銀行允許幣別資料
    /// </summary>
    [Table("CustomerBankCurrency")]
    public class CustomerBankCurrency
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
        [Column("cbc_customer_id")]
        public int CustomerId { get; set; }
        /// <summary>
        /// 幣別ID
        /// </summary>
        [Column("cbc_currency_id")]
        public int CurrencyId { get; set; }
    }
}
