using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class AuthCtrl
    {
        /// <summary>
        /// 用戶權限控管ID
        /// </summary>
        [Key]
        public int AuthCtrlID { get; set; }
        /// <summary>
        /// 用戶權限控管用戶AD代號
        /// </summary>
        public int ADID { get; set; }
        /// <summary>
        /// 用戶權限控管棤限列表id
        /// </summary>
        public short FuncListID { get; set; }
        /// <summary>
        /// 用戶權限控管帳號id
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
