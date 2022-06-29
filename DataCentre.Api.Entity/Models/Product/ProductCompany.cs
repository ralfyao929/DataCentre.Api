using Dapper;

namespace DataCentre.Api.Entity.Models.Product
{
    /// <summary>
    /// 請求產品資料隸屬公司
    /// </summary>
    [Table("ProductCompany")]
    public class ProductCompany
    {
        /// <summary>
        /// Database PK
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        [Column("pc_company_id")]
        public int CompanyId { get; set; }
        [Column("pc_product_id")]
        public int ProductId { get; set; }
        [Column("pc_create_user")]
        public string CreateUser { get; set; }
        [Column("pc_create_date")]
        public DateTime CreateDate { get; set; }
    }
}
