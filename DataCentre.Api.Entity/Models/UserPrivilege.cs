﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.Entity.Models
{
    [Table("UserPrivileges")]
    public class UserPrivilege
    {
        public string PrivilegeGroup { get; set; }
        public int PrivilegeId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
