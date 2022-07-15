using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class CurrencyBase
    {
        /// <summary>
        /// 交易幣別ID
        /// </summary>
        [Key]
        public short CurrencyBaseID { get; set; }
        /// <summary>
        /// 交易幣別名稱
        /// </summary>
        public string? CurrencyBaseName { get; set; }
        /// <summary>
        /// 交易幣別英文簡稱
        /// </summary>
        public string? CurrencyBaseEName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
