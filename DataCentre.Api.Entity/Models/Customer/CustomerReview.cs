using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
}
