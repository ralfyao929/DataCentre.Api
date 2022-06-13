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
        [Column("a_id")]
        public int ID { get; set; }
        /// <summary>
        /// 從客端傳過來的APIUrl
        /// </summary>
        [Column("a_apiurl")]
        public string APIUrl { get; set; }
        /// <summary>
        /// 客端傳遞過來的HTTP Method
        /// </summary>
        [Column("a_method")]
        public string Method { get; set; }
        /// <summary>
        /// 使用者帳號
        /// </summary>
        [Column("a_user")]
        public string User { get; set; }
        /// <summary>
        /// 客端傳遞過來的HTTP Request的表單轉為JSON字串
        /// </summary>
        [Column("a_request_json")]
        public string RequestJson { get; set; }
        /// <summary>
        /// 回傳給客端的JSON字串
        /// </summary>
        [Column("a_response_json")]
        public string ResponseJson { get; set; }
        /// <summary>
        /// 回傳給客端的RESPONSE CODE
        /// </summary>
        [Column("a_response_code")]
        public string ResponseCode { get; set; }
        /// <summary>
        /// 回傳給客端的建立日期時間
        /// </summary>
        [Column("a_created_time")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedTime { get; set; }
    }
}
