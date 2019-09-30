using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceEmailContent
    {
        public int EmailContentId { get; set; }
        public int EmailProfileId { get; set; }
        public int EmailTypeId { get; set; }
        public string CultureCode { get; set; }
        public string Subject { get; set; }
        public string ContentId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceEmailProfile EmailProfile { get; set; }
        public virtual UCommerceEmailType EmailType { get; set; }
    }
}
