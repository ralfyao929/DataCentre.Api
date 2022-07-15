using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class CompanyDiv
    {
        /// <summary>
        /// 公司單位ID
        /// </summary>
        [Key]
        public short CompanyDivID { get; set; }
        /// <summary>
        /// 公司單位名稱
        /// </summary>
        public string? CompanyDivName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
