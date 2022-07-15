using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class UserBase
    {
        /// <summary>
        /// 登入帳號ID
        /// </summary>
        [Key]
        public int UserBaseID { get; set; }
        /// <summary>
        /// 登入帳號名稱
        /// </summary>
        public string? UserBaseName { get; set; }
        /// <summary>
        /// 登入帳號帳號
        /// </summary>
        public string? UserBaseNo { get; set; }
        /// <summary>
        /// 登入帳號密碼
        /// </summary>
        public string? UserBasePwd { get; set; }
        /// <summary>
        /// 登入帳號ADID
        /// </summary>
        public int UserBaseADID { get; set; }
        /// <summary>
        /// 登入帳號是否失敗
        /// </summary>
        public bool UserBaseInvalid { get; set; }
        /// <summary>
        /// 登入帳號是否刪除
        /// </summary>
        public bool UserBaseIsDelete { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
