using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class TableList
    {
        /// <summary>
        /// 資料表代號
        /// </summary>
        [Key]
        public string? TableNo { get; set; }
        /// <summary>
        /// 資料表名稱
        /// </summary>
        public string? TableName { get; set; }
        /// <summary>
        /// 類別
        /// </summary>
        public int TableType { get; set; }
        public int tbord { get; set; }
        /// <summary>
        /// 預設新增欄位
        /// </summary>
        public string? DefCol { get; set; }
        /// <summary>
        /// 預設資料
        /// </summary>
        public string? DefData { get; set; }
    }
}
