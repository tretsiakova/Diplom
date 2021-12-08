using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class MobileStatus
    {
        public int Id { get; set; }

        [DisplayName("Статус")]
        public string StatusName { get; set; }

        public List<Mobile> Mobiles { get; set; }
    }
}
