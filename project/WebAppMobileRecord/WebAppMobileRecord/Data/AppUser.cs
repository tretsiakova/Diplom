#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebAppMobileRecord.Data
{
    public class AppUser: IdentityUser
    {
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }


        public List<AssignMobileIdentity> AssignMobileIdentities { get; set; }
        
    }
}
