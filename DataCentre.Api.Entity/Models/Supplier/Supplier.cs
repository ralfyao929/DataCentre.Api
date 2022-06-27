using Dapper;

namespace DataCentre.Api.Entity.Models.Supplier
{
    /// <summary>
    /// 供應商
    /// </summary>
    [Table("Supplier")]
    public class Supplier
    {
        /// <summary>
        /// Database PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 供應商ID
        /// </summary>
        [Column("s_id")]
        public int SupplierId { get; set; }
        /// <summary>
        /// 我的公司ID
        /// </summary>
        [Column("s_company_id")]
        public int CompanyId { get; set; }
        /// <summary>
        /// 負責單位代號
        /// </summary>
        [Column("s_department_id")]
        public int DepartmentId { get; set; }
        /// <summary>
        /// 抬頭
        /// </summary>
        [Column("s_title")]
        public string? Title { get; set; }
        /// <summary>
        /// 供應商名稱
        /// </summary>
        [Column("s_supplier_name")]
        public string? SupplierName { get; set; }
        /// <summary>
        /// 統編
        /// </summary>
        [Column("s_uni_number")]
        public int? UniNumber { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        [Column("s_comment")]
        public string Comment { get; set; }
        /// <summary>
        /// 月結天數id
        /// </summary>
        [Column("s_month_settlement_day_id")]
        public int MonthSettlementDayId { get; set; }
        /// <summary>
        /// 供應商聯絡人列表ID
        /// </summary>
        [Column("s_contact_data_id")]
        public int SupplierContactDataId { get; set; }
        /// <summary>
        /// 供應商聯絡人列表
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<SupplierContact>? SupplierContactList { get; set; }
        /// <summary>
        /// 供應商匯款銀行資料列表ID
        /// </summary>
        [Column("s_bank_id")]
        public int SupplierBankId { get; set; }
        /// <summary>
        /// 供應商匯款銀行列表
        /// </summary>
        [IgnoreInsert]
        [IgnoreUpdate]
        [IgnoreSelect]
        public List<SupplierBank>? SupplierBankList { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("s_creator")]
        public string Creator { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("s_create_date")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("s_modifier")]
        public string Modifier { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [Column("s_modify_date")]
        public DateTime? ModifyDate { get; set; }
    }
    /// <summary>
    /// 供應商聯絡人
    /// </summary>
    [Table("SupplierContact")]
    public class SupplierContact
    {
        /// <summary>
        /// Database PK
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 供應商ID
        /// </summary>
        [Column("sc_supplier_id")]
        public int SupplierId { get; set; }
        /// <summary>
        /// 供應商聯絡人姓名
        /// </summary>
        [Column("sc_contact_name")]
        public string SupplierContactName { get; set; }
        /// <summary>
        /// 供應商聯絡人電話
        /// </summary>
        [Column("sc_contact_tel")]
        public string SupplierContactTel { get; set; }
        /// <summary>
        /// 供應商聯絡人電話
        /// </summary>
        [Column("sc_contact_address")]
        public string SupplierContactAddress { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("sc_creator")]
        public string Creator { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("sc_create_date")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("sc_modifier")]
        public string Modifier { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [Column("sc_modify_date")]
        public DateTime? ModifyDate { get; set; }
    }
    /// <summary>
    /// 供應商銀行資料
    /// </summary>
    [Table("SupplierBank")]
    public class SupplierBank 
    {
        /// <summary>
        /// Database PK
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 供應商id
        /// </summary>
        [Column("sb_supplier_id")]
        public int SupplierId { get; set; }
        /// <summary>
        /// 銀行帳號
        /// </summary>
        [Column("sb_bank_account")]
        public string BankAccount { get; set; }
        /// <summary>
        /// 銀行名
        /// </summary>
        [Column("sb_bank_name")]
        public string BankName { get; set; }
        /// <summary>
        /// 分行名稱
        /// </summary>
        [Column("sb_branch_name")]
        public string BranchName { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("sb_creator")]
        public string Creator { get; set; }
        /// <summary>
        /// 建立日期
        /// </summary>
        [Column("sb_create_date")]
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("sb_modifier")]
        public string Modifier { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        [Column("sb_modify_date")]
        public DateTime ModifyDate { get; set; }
    }
}
