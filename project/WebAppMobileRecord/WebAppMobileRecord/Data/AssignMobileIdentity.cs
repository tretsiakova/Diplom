using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class AssignMobileIdentity
    {
        public int Id { get; set; }
        
        public DateTime AssignDate { get; set; }

        public DateTime UnAssignDate { get; set; }

        public int IdentityId { get; set; }
        public IdentityUser Identity { get; set; }

        public int MobileId { get; set; }

        public Mobile Mobile { get; set; }
    }
}
