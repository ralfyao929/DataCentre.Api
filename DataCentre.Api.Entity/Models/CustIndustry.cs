using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class CustIndustry
    {
        /// <summary>
        /// 客戶產業ID
        /// </summary>
        [Key]
        public short CustIndustryID { get; set; }
        /// <summary>
        /// 客戶產業名稱
        /// </summary>
        public string? CustIndustryName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
