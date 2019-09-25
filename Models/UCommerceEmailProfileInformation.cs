using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceEmailProfileInformation
    {
        public int EmailProfileInformationId { get; set; }
        public int EmailProfileId { get; set; }
        public int EmailTypeId { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
        public string CcAddress { get; set; }
        public string BccAddress { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceEmailProfile EmailProfile { get; set; }
        public virtual UCommerceEmailType EmailType { get; set; }
    }
}
