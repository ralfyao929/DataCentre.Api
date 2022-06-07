using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models
{
    public class APILog
    {
        [Key]
        public int ID { get; set; }
        public string APIUrl { get; set; }
        public string Method { get; set; }
        public string User { get; set; }
        public string RequestJson { get; set; }
        public string ResponseJson { get; set; }
        public string ResponseCode { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
