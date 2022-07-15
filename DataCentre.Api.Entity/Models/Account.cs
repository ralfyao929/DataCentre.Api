using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class Account
    {
        /// <summary>
        /// 會計科目ID
        /// </summary>
        [Key]
        public short AccountID { get; set; }
        /// <summary>
        /// 會計科目名稱
        /// </summary>
        public string? AccountName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
