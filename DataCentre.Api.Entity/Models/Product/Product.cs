using Dapper;
using DataCentre.Api.Entity.Models.Accounting;

namespace DataCentre.Api.Entity.Models.Product
{
    /// <summary>
    /// 產品資料
    /// </summary>
    [Table("Product")]
    public class Product
    {
        public Product() { }
        public Product(ProductReview productReview)
        {
            ProductId = productReview.ProductId;
            productTypeId = (int)(productReview.productTypeId!=null ? productReview.productTypeId : -1);
            productName1 = productReview.productName1;
            productName2 = productReview.productName2;
            productClassId = (int)(productReview.productClassId != null ? productReview.productClassId : -1);
            productTypeId = (int)(productReview.productTypeId != null ? productReview.productTypeId : -1);
            personInChargeId = (int)(productReview.personInChargeId != null ? productReview.personInChargeId : -1);
            isSetCost = (int)(productReview.isSetCost != null ? productReview.isSetCost : -1);
            accounting = (int)(productReview.accounting != null ? productReview.accounting : -1);
            accountingBranch = (int)(productReview.accountingBranch != null ? productReview.accountingBranch : -1);
            accountingProductType = (int)(productReview.accountingProductType != null ? productReview.accountingProductType : -1);
            companyId = productReview.companyId;
            departmentId = (int)(productReview.departmentId != null ? productReview.departmentId : -1);
            supplierName = (int)(productReview.supplierName != null ? productReview.supplierName : -1);
            createUser = productReview.createUser;
            createdTime = productReview.createdTime;
            modifyUser = productReview.reviewer;
            modifyTime = DateTime.Now;
        }
        /// <summary>
        /// 資料PK
        /// </summary>
        [Key]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 產品ID
        /// </summary>
        [Column("p_id")]
        public int? ProductId { get; set; }
        /// <summary>
        /// 產品別ID
        /// </summary>
        [Column("p_product_type_id")]
        public int productTypeId { get; set; }
        /// <summary>
        /// 產品細項總稱
        /// </summary>
        [Column("p_product_general_name")]
        public string? productName1 { get; set; }
        /// <summary>
        /// 產品細項
        /// </summary>
        [Column("p_product_detail_name")]
        public string? productName2 { get; set; }
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
        [Column("p_responser_dept_id")]
        public int departmentId { get; set; }
        /// <summary>
        /// 是否列入成本
        /// </summary>
        [Column("p_is_cost")]
        public int isSetCost { get; set; }
        /// <summary>
        /// 會計科目id
        /// </summary>
        [Column("p_account_id")]
        public int accounting { get; set; }
        /// <summary>
        /// 會計子科目id
        /// </summary>
        [Column("p_account_sub_id")]
        public int accountingBranch { get; set; }
        /// <summary>
        /// 會計產品別id
        /// </summary>
        [Column("p_account_prod_id")]
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
        public DateTime? createdTime { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("p_modify_user")]
        public string modifyUser { get; set; }
        /// <summary>
        /// 修改時間
        /// </summary>
        [Column("p_modify_time")]
        public DateTime? modifyTime { get; set; }
    }
}
