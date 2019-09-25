using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceEmailProfile
    {
        public UCommerceEmailProfile()
        {
            UCommerceEmailContent = new HashSet<UCommerceEmailContent>();
            UCommerceEmailProfileInformation = new HashSet<UCommerceEmailProfileInformation>();
            UCommerceProductCatalogGroup = new HashSet<UCommerceProductCatalogGroup>();
        }

        public int EmailProfileId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceEmailContent> UCommerceEmailContent { get; set; }
        public virtual ICollection<UCommerceEmailProfileInformation> UCommerceEmailProfileInformation { get; set; }
        public virtual ICollection<UCommerceProductCatalogGroup> UCommerceProductCatalogGroup { get; set; }
    }
}
