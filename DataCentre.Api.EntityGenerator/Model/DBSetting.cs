using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCentre.Api.EntityGenerator.Model
{
    public class DBSetting
    {
        public string DB_IP { get; set; }
        public string DB_PORT { get; set; }
        public string DB_USER { get; set; }
        public string DB_PASS { get; set; }
        public string DB_NAME { get; set; }
        public string DB_TYPE { get; set; }
    }
}
