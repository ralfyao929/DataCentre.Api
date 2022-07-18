using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class TableColumn
    {
        /// <summary>
        /// 資料表代號
        /// </summary>
        [Key]
        public string? TableNo { get; set; }
        /// <summary>
        /// 欄位代號
        /// </summary>
        [Key]
        public string? ColumnNo { get; set; }
        /// <summary>
        /// 欄位名稱
        /// </summary>
        public string? ColumnName { get; set; }
        /// <summary>
        /// 順序
        /// </summary>
        public short ColOrd { get; set; }
    }
}
