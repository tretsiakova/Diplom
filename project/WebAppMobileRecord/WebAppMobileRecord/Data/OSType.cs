using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class OSType
    {
        public int Id { get; set; }

        [DisplayName("Тип ОС")]
        public string OSTypeName { get; set; }

        public List<OSVersion> OsVersions { get; set; }
    }
}
