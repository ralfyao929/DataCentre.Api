using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class Custmer
    {
        /// <summary>
        /// 客戶基本資料ID
        /// </summary>
        [Key]
        public short CustmerID { get; set; }
        /// <summary>
        /// 客戶基本資料負責公司ID
        /// </summary>
        public short CommpanyID { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
