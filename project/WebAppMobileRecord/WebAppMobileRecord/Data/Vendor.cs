using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class Vendor
    {
        public int Id {get;set;}

        [DisplayName("Поставщи")]
        public string VendorName { get; set; }


        public List<Mobile> Mobiles { get; set; }
    }
}
