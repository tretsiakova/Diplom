#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebAppMobileRecord.Data
{
    public class AppUser: IdentityUser
    {

        [DisplayName("ФИО")]
        public string? FullName { get; set; }

        [DisplayName("Номер места")]
        public string? PlaceNumber { get; set; }

        public List<AssignMobileIdentity> AssignMobileIdentities { get; set; }
        
    }
}
