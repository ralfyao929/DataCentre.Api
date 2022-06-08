using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models
{
    [Table("PrivilegeData")]
    public class PrivilegeData
    {
        [Key]
        public int Id { get; set; }
        public string PrivilegeName { get; set; }
        public int PrivilegeType { get; set; }
    }
}
