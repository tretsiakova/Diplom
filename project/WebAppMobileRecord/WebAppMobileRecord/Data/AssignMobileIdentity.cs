﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class AssignMobileIdentity
    {
        public int Id { get; set; }
        
        public DateTime AssignDate { get; set; }

        public DateTime? UnAssignDate { get; set; }

        [Key]
        public string IdentityId { get; set; }

        [ForeignKey("IdentityId")]
        public virtual AppUser Identity { get; set; }

        public int MobileId { get; set; }

        public Mobile Mobile { get; set; }
    }
}
