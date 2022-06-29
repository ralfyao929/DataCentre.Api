using Dapper;

namespace DataCentre.Api.Entity.Models.Sales
{
    [Table("SalesOrder")]
    public class SalesOrder
    {
        [Column("id")]
        public int id { get; set; }
        [Column("s_product_id_key")]
        public int ProductIdKey { get; set; }
        [Column("s_company_id")]
        public int CompanyId { get; set; }
    }
    [Table("SalesOrderProduct")]
    public class SalesOrderProduct
    {
        [Column("id")]
        public int id { get; set; }
        [Column("s_product_id_order_key")]
        public int ProductIdKey { get; set; }
        [Column("s_product_id")]
        public int ProductId { get; set; }
    }
}
