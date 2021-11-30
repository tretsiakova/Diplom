using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMobileRecord.Data
{
    public class Mobile
    {
        public int Id { get; set; }

        [DisplayName("Номер устройства")]
        public string Number { get; set; }

        [DisplayName("Дата добавления")]
        public DateTime AddedDate { get; set; }

        [DisplayName("Дата деактивации")]
        public DateTime? DeactivatedDate { get; set; }

        [DisplayName("Версия ОС")]
        public int OSVersionId { get; set; }


        [DisplayName("Версия ОС")]
        public OSVersion OSVersion { get; set; }

        [DisplayName("Статус")]
        public int MobileStatusId { get; set; }


        [DisplayName("Статус")]
        public MobileStatus MobileStatus { get; set; }


        [DisplayName("Тип устройства")]
        public int MobileTypeId { get; set; }


        [DisplayName("Тип устройства")]
        public MobileType MobileType { get; set; }


        [DisplayName("Производитель")]
        public int VendorId { get; set; }

        [DisplayName("Производитель")]
        public Vendor Vendor { get; set; }


        [DisplayName("Комментарий")]
        public string? Comment { get; set; }

        public List<AssignMobileIdentity> AssignMobileIdentities { get; set; }
    }
}
