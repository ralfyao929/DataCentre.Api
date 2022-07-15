using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class ProductType
    {
        /// <summary>
        /// 產品別ID
        /// </summary>
        [Key]
        public short ProductTypeID { get; set; }
        /// <summary>
        /// 產品別名稱
        /// </summary>
        public string? ProductTypeName { get; set; }
        /// <summary>
        /// 產品別發票名稱
        /// </summary>
        public string? ProductTypeInvName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
