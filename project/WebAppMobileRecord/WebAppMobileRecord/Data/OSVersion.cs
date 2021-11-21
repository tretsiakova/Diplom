using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class OSVersion
    {
        public int Id { get; set; }

        public string Version { get; set; }

        public int OSTypeId { get; set; }
        public OSType OSType { get; set; }
    }
}
