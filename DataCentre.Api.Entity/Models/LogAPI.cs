using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class LogAPI
    {
        /// <summary>
        /// APIlogID
        /// </summary>
        [Key]
        public int LogAPIID { get; set; }
        /// <summary>
        /// APIlogAPIUrl
        /// </summary>
        public string? LogAPIUrl { get; set; }
        /// <summary>
        /// APIlogMethod
        /// </summary>
        public string? LogAPIMethod { get; set; }
        /// <summary>
        /// APIlogCallUser
        /// </summary>
        public string? LogAPICallUser { get; set; }
        /// <summary>
        /// APIlogInputData
        /// </summary>
        public string? LogAPIInputData { get; set; }
        /// <summary>
        /// APIlogOutData
        /// </summary>
        public string? LogAPIOuptData { get; set; }
        /// <summary>
        /// APIlogResponeCode
        /// </summary>
        public string? LogAPIResponeCode { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
