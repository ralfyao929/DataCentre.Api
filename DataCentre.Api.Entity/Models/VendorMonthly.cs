using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class VendorMonthly
    {
        /// <summary>
        /// 廠商月結資料ID
        /// </summary>
        [Key]
        public short VendorMonthlyID { get; set; }
        /// <summary>
        /// 廠商月結資料天數
        /// </summary>
        public short VendorMonthlyDay { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
