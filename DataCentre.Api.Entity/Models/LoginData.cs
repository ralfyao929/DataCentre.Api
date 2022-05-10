using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models
{
    [Table("LoginData")]
    public class LoginData
    {
        [Required(ErrorMessage="User Name is required")]
        [Key]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        public string PrivilegeGroup { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUser { get; set; }

    }
}
