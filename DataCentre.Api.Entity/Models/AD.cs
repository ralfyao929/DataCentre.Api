using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class AD
    {
        /// <summary>
        /// AD資料ID
        /// </summary>
        [Key]
        public int ADID { get; set; }
        /// <summary>
        /// AD資料中文全名
        /// </summary>
        public string? ADName { get; set; }
        /// <summary>
        /// AD資料部門名稱
        /// </summary>
        public string? ADDeptName { get; set; }
        /// <summary>
        /// AD資料英文全名
        /// </summary>
        public string? ADEName { get; set; }
        /// <summary>
        /// AD資料Email
        /// </summary>
        public string? ADEmail { get; set; }
        /// <summary>
        /// AD資料是否失效
        /// </summary>
        public bool ADInvalid { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
