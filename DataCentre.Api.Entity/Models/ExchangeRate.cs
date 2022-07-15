using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class ExchangeRate
    {
        /// <summary>
        /// 幣別匯率ID
        /// </summary>
        [Key]
        public short ExchangeRateID { get; set; }
        /// <summary>
        /// 幣別匯率設定年月
        /// </summary>
        public string? ExchangeRateYM { get; set; }
        /// <summary>
        /// 幣別匯率基準幣別
        /// </summary>
        public short CurrencyID { get; set; }
        /// <summary>
        /// 幣別匯率換算幣別
        /// </summary>
        public short ExCurrencyID { get; set; }
        /// <summary>
        /// 幣別匯率匯率
        /// </summary>
        public decimal ExchangeRateRate { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
