using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class Vendor
    {
        /// <summary>
        /// 供應商基本資料ID
        /// </summary>
        [Key]
        public short VendorID { get; set; }
        /// <summary>
        /// 供應商基本資料名稱
        /// </summary>
        public string? VendorName { get; set; }
        /// <summary>
        /// 供應商基本資料信箱
        /// </summary>
        public string? VendorEMail { get; set; }
        /// <summary>
        /// 供應商基本資料電話
        /// </summary>
        public string? VendorTEL { get; set; }
        /// <summary>
        /// 供應商基本資料備註
        /// </summary>
        public string? VendorREM { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
