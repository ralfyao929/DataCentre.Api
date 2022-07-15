using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class Country
    {
        /// <summary>
        /// 隸屬國家ID
        /// </summary>
        [Key]
        public short CountryID { get; set; }
        /// <summary>
        /// 隸屬國家名稱
        /// </summary>
        public string? CountryName { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
