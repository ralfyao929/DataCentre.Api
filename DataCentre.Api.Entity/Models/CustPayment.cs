using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class CustPayment
    {
        /// <summary>
        /// 客戶付款條件ID
        /// </summary>
        [Key]
        public short CustPaymentID { get; set; }
        /// <summary>
        /// 客戶付款條件天數
        /// </summary>
        public short CustPaymentDay { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
