using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceEmailType
    {
        public UCommerceEmailType()
        {
            UCommerceEmailContent = new HashSet<UCommerceEmailContent>();
            UCommerceEmailProfileInformation = new HashSet<UCommerceEmailProfileInformation>();
            UCommerceEmailTypeParameter = new HashSet<UCommerceEmailTypeParameter>();
        }

        public int EmailTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceEmailContent> UCommerceEmailContent { get; set; }
        public virtual ICollection<UCommerceEmailProfileInformation> UCommerceEmailProfileInformation { get; set; }
        public virtual ICollection<UCommerceEmailTypeParameter> UCommerceEmailTypeParameter { get; set; }
    }
}
