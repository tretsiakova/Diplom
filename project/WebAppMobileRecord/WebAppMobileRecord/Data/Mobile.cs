using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class Mobile
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? DeactivatedDate { get; set; }

        public int OSVersionId { get; set; }

        public OSVersion OSVersion { get; set; }

        public int MobileStatusId { get; set; }

        public MobileStatus MobileStatus { get; set; }


        public int MobileTypeId { get; set; }

        public MobileType MobileType { get; set; }


        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public List<AssignMobileIdentity> AssignMobileIdentities { get; set; }
    }
}
