using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppMobileRecord.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<MobileStatus> MobileStatuses { get; set; }
        public DbSet<MobileType> MobileTypes { get; set; }
        public DbSet<OSType> OSTypes { get; set; }
        public DbSet<OSVersion> OSVersions { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<AssignMobileIdentity> AssignMobileIdentities { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
