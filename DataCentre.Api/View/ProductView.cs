using DataCentre.Api.Entity.Models.Product;

namespace DataCentre.Api.View
{
    public class ProductView:ProductReview
    {
        public Product product;
        public ProductMainView prodMainView;
        /// <summary>
        /// 要被修改的產品資料
        /// </summary>
        public int? oldProductId { get; set; }
        ///// <summary>
        ///// 產品別ID
        ///// </summary>
        //public int? productTypeId { get; set; }
        ///// <summary>
        ///// 產品細項總稱
        ///// </summary>
        //public string? productName1 { get; set; }
        ///// <summary>
        ///// 產品細項
        ///// </summary>
        //public string? productName2 { get; set; }
        ///// <summary>
        ///// 產品類ID
        ///// </summary>
        //public int? productClassId { get; set; }
        /// <summary>
        /// 隸屬公司(負責公司)ID
        /// </summary>
        public string? companyIdArray { get; set; }
        ///// <summary>
        ///// 供應商ID
        ///// </summary>
        //public int? supplierName { get; set; }
        ///// <summary>
        ///// 產品負責人ID     這是AD
        ///// </summary>
        //public int? personInChargeId { get; set; }
        ///// <summary>
        ///// 產品負責單位id
        ///// </summary>
        //public int? departmentId { get; set; }
        ///// <summary>
        ///// 我選的會計科目id
        ///// </summary>
        //public int? accounting { get; set; }
        ///// <summary>
        ///// 我選的會計子目id
        ///// </summary>
        //public int? accountingBranch { get; set; }
        ///// <summary>
        ///// 我選的會計產品別id
        ///// </summary>
        //public int? accountingProductType { get; set; }
        ///// <summary>
        ///// 是否列入成本
        ///// </summary>
        //public int? isSetCost { get; set; }
    }
}
