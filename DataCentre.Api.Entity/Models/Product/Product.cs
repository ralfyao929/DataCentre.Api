using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models.Product
{
    /// <summary>
    /// 產品資料
    /// </summary>
    [Table("Product")]
    public class Product
    {
        /// <summary>
        /// 資料PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 產品別ID
        /// </summary>
        [Column("p_product_type_id")]
        public int productTypeId { get; set; }
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
        public int productClassId { get; set; }
        /// <summary>
        /// 隸屬公司ID
        /// </summary>
        [Column("p_belongto_company_id")]
        public int companyId { get; set; }
        /// <summary>
        /// 供應商ID
        /// </summary>
        [Column("p_supplier_name")]
        public int supplierName { get; set; }
        /// <summary>
        /// 負責人ID
        /// </summary>
        [Column("p_responser_id")]
        public int personInChargeId { get; set; }
        /// <summary>
        /// 負責單位
        /// </summary>
        [Column("p_responser_dept")]
        public string departmentId { get; set; }
        /// <summary>
        /// 是否列入成本
        /// </summary>
        [Column("p_is_cost")]
        public int isSetCost { get; set; }
        /// <summary>
        /// 會計科目id
        /// </summary>
        [Column("p_account")]
        public int accounting { get; set; }
        /// <summary>
        /// 會計子科目id
        /// </summary>
        [Column("p_account_sub")]
        public int accountingBranch { get; set; }
        /// <summary>
        /// 會計產品別id
        /// </summary>
        [Column("p_account_prod")]
        public int accountingProductType { get; set; }
        /// <summary>
        /// 建立者
        /// </summary>
        [Column("p_create_user")]
        public string createUser { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [Column("p_created_time")]
        public DateTime createdTime { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("p_modify_user")]
        public string modifyUser { get; set; }
        /// <summary>
        /// 修改時間
        /// </summary>
        [Column("p_modify_time")]
        public DateTime modifyTime { get; set; }

    }
}
