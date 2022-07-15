using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class Commpany
    {
        /// <summary>
        /// 我的公司ID
        /// </summary>
        [Key]
        public short CommpanyID { get; set; }
        /// <summary>
        /// 我的公司名稱
        /// </summary>
        public string? CommpanyName { get; set; }
        /// <summary>
        /// 我的公司幣別ID
        /// </summary>
        public short CurrencyID { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
