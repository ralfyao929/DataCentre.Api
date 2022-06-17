using Dapper;

namespace DataCentre.Api.Entity.Models.Product
{
    /// <summary>
    /// 產品別
    /// </summary>
    [Table("ProductClass")]
    public class ProductClass
    {
        /// <summary>
        /// PK
        /// </summary>
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// 產品類ID
        /// </summary>
        [Column("pc_id")]
        public int ProductClassId { get; set; }
        /// <summary>
        /// 產品類名稱
        /// </summary>
        [Column("pc_name")]
        public string ProductClassName { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [Column("pc_created_time")]
        public string CreateTime { get; set; }
        /// <summary>
        /// 建立人員
        /// </summary>
        [Column("pc_creator")]
        public string Creator { get; set; }
        /// <summary>
        /// 修改人員
        /// </summary>
        [Column("pc_modifor")]
        public string ModifyUser { get; set; }
        /// <summary>
        /// 修改時間
        /// </summary>
        [Column("pc_mdoify_time")]
        public string ModifyDate { get; set; }
        
    }
}
