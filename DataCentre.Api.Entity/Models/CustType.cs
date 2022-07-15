using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class CustType
    {
        /// <summary>
        /// 客戶類別ID
        /// </summary>
        [Key]
        public short CustTypeID { get; set; }
        /// <summary>
        /// 客戶類別名稱
        /// </summary>
        public string? CustTypeName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
