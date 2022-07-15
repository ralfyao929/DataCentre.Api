using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class RevBankAcnt
    {
        /// <summary>
        /// 匯入款帳號ID
        /// </summary>
        [Key]
        public short RevBankAcntID { get; set; }
        /// <summary>
        /// 匯入款帳號名稱
        /// </summary>
        public string? RevBankAcntName { get; set; }
        /// <summary>
        /// 匯入款帳號我的公司ID
        /// </summary>
        public short CommpanyID { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
