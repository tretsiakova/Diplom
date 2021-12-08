using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class MobileType
    {
        public int Id { get; set; }

        [DisplayName("Тип устройства")]
        public string TypeName { get; set; }

        public List<Mobile> Mobiles { get; set; }
    }
}
