using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class OSVersion
    {
        public int Id { get; set; }

        [DisplayName("Версия")]
        public string Version { get; set; }

        [DisplayName("Тип ОС")]
        public int OSTypeId { get; set; }

        [DisplayName("Тип ОС")]
        public OSType OSType { get; set; }


        public List<Mobile> Mobiles { get; set; }
    }
}
