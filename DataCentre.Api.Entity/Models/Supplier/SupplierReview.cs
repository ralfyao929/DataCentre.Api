using Dapper;

namespace DataCentre.Api.Entity.Models.Supplier
{
    [Table("SupplierReview")]
    public class SupplierReview
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

    }
}
