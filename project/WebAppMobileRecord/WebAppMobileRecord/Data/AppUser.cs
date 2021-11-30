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
        public string? FullName { get; set; }
        public string? PlaceNumber { get; set; }

        public List<AssignMobileIdentity> AssignMobileIdentities { get; set; }
        
    }
}
