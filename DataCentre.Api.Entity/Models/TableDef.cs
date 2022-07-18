using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class TableDef
    {
        /// <summary>
        /// 資料表定義
        /// </summary>
        [Key]
        public string? TableType { get; set; }
        /// <summary>
        /// 資料欄代號
        /// </summary>
        [Key]
        public string? DefColumn { get; set; }
        /// <summary>
        /// 資料欄名 稱
        /// </summary>
        public string? DefName { get; set; }
        public string? DefDataType { get; set; }
        public int DefLen { get; set; }
        public bool PK { get; set; }
        public short ord { get; set; }
        /// <summary>
        /// FK資料表
        /// </summary>
        public string? FKTable { get; set; }
        public string? FKCol { get; set; }
        /// <summary>
        /// 自動加1
        /// </summary>
        public bool AutoInc { get; set; }
        /// <summary>
        /// 預設值
        /// </summary>
        public string? DefaultValue { get; set; }
    }
}
