using Dapper;

namespace DataCentre.Api.Entity.Models.Supplier
{
    [Table("Supplier")]
    public class Supplier
    {
        [Column("id")]
        public int id { get; set; }
    }
}
