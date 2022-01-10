using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class AssignMobileIdentity
    {

        [Key]
        public int Id { get; set; }


        [DisplayName("Дата назначения")]
        public DateTime AssignDate { get; set; }

        [DisplayName("Дата снятия")]
        public DateTime? UnAssignDate { get; set; }

        [DisplayName("Сотрудник")]
        public string? IdentityId { get; set; }

        [ForeignKey("IdentityId")]
        [DisplayName("Сотрудник")]
        public AppUser? Identity { get; set; }

        [DisplayName("Устройство")]
        public int MobileId { get; set; }

        [DisplayName("Устройство")]
        public Mobile Mobile { get; set; }
    }
}
