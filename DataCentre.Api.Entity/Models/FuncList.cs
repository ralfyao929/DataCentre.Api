using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class FuncList
    {
        /// <summary>
        /// 權限功能列表ID
        /// </summary>
        [Key]
        public short FuncListID { get; set; }
        /// <summary>
        /// 權限功能列表名稱
        /// </summary>
        public string? FuncListName { get; set; }
        /// <summary>
        /// 權限功能列表UI顯示類別
        /// </summary>
        public string? FuncListType { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
