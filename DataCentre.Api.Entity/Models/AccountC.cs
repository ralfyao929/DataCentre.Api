using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class AccountC
    {
        /// <summary>
        /// 會計子科目ID
        /// </summary>
        [Key]
        public short AccountCID { get; set; }
        /// <summary>
        /// 會計子科目名稱
        /// </summary>
        public string? AccountCName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
