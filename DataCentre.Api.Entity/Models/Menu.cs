using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class Menu
    {
        /// <summary>
        /// 系統選單ID
        /// </summary>
        [Key]
        public short MenuID { get; set; }
        /// <summary>
        /// 系統選單代號
        /// </summary>
        public string? MenuCode { get; set; }
        /// <summary>
        /// 系統選單代號名稱
        /// </summary>
        public string? MenuCodeName { get; set; }
        /// <summary>
        /// 系統選單上層代號
        /// </summary>
        public string? MenuParentCode { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
