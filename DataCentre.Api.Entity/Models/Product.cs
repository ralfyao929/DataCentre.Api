using System;
using Dapper;
namespace DataCentre.Api.Entity.Models
{
    public class Product
    {
        /// <summary>
        /// 產品資料ID
        /// </summary>
        [Key]
        public int ProductID { get; set; }
        /// <summary>
        /// 產品資料名稱
        /// </summary>
        public string? ProductName { get; set; }
        /// <summary>
        /// 產品資料細項
        /// </summary>
        public string? ProductFullName { get; set; }
        /// <summary>
        /// 產品資料產品別id
        /// </summary>
        public short ProductTypeID { get; set; }
        /// <summary>
        /// 產品資料產品類id
        /// </summary>
        public short ProductClassID { get; set; }
        /// <summary>
        /// 產品資料公司單位
        /// </summary>
        public short CompanyDivID { get; set; }
        /// <summary>
        /// 產品資料公司id
        /// </summary>
        public short CommpanyID { get; set; }
        /// <summary>
        /// 產品資料供應商id
        /// </summary>
        public short VendorID { get; set; }
        /// <summary>
        /// 產品資料會計科目id
        /// </summary>
        public short AccountID { get; set; }
        /// <summary>
        /// 產品資料會計子科目id
        /// </summary>
        public short AccountCID { get; set; }
        /// <summary>
        /// 產品資料會計產品別id
        /// </summary>
        public short AccountProdID { get; set; }
        /// <summary>
        /// 產品資料是否列入成本
        /// </summary>
        public bool ProductInCost { get; set; }
        /// <summary>
        /// 產品資料負責人id
        /// </summary>
        public int PersonADID { get; set; }
        /// <summary>
        /// createdTime
        /// </summary>
        public DateTime createdTime { get; set; }
    }
}
