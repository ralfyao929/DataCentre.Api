using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class AccountProd
    {
        /// <summary>
        /// 會計科目產品別ID
        /// </summary>
        [Key]
        public short AccountProdID { get; set; }
        /// <summary>
        /// 會計科目產品別名稱
        /// </summary>
        public string? AccountProdName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
