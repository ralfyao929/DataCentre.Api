using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models
{
    [Table("APILog")]
    public class APILog
    {
        /// <summary>
        /// 資料表的PK
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int ID { get; set; }
        /// <summary>
        /// 從客端傳過來的APIUrl
        /// </summary>
        [Column("APIUrl")]
        public string APIUrl { get; set; }
        /// <summary>
        /// 客端傳遞過來的HTTP Method
        /// </summary>
        [Column("Method")]
        public string Method { get; set; }
        /// <summary>
        /// 使用者帳號
        /// </summary>
        [Column("User")]
        public string User { get; set; }
        /// <summary>
        /// 客端傳遞過來的HTTP Request的表單轉為JSON字串
        /// </summary>
        [Column("RequestJson")]
        public string RequestJson { get; set; }
        /// <summary>
        /// 回傳給客端的JSON字串
        /// </summary>
        [Column("ResponseJson")]
        public string ResponseJson { get; set; }
        /// <summary>
        /// 回傳給客端的RESPONSE CODE
        /// </summary>
        [Column("ResponseCode")]
        public string ResponseCode { get; set; }
        /// <summary>
        /// 回傳給客端的建立日期時間
        /// </summary>
        [Column("CreatedTime")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedTime { get; set; }
    }
}
