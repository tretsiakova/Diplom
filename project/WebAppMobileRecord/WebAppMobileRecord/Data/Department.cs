﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AppUser> AppUsers { get; set; }
    }
}