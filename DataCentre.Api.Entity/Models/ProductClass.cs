using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class ProductClass
    {
        /// <summary>
        /// 產品類ID
        /// </summary>
        [Key]
        public short ProductClassID { get; set; }
        /// <summary>
        /// 產品類名稱
        /// </summary>
        public string? ProductClassName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
