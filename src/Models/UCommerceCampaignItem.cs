using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCampaignItem
    {
        public UCommerceCampaignItem()
        {
            UCommerceAward = new HashSet<UCommerceAward>();
            UCommerceCampaignItemProperty = new HashSet<UCommerceCampaignItemProperty>();
            UCommerceTarget = new HashSet<UCommerceTarget>();
        }

        public int CampaignItemId { get; set; }
        public int CampaignId { get; set; }
        public int DefinitionId { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public int? Priority { get; set; }
        public bool AllowNextCampaignItems { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool Deleted { get; set; }
        public bool AnyTargetAppliesAwards { get; set; }
        public bool? AnyTargetAdvertises { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCampaign Campaign { get; set; }
        public virtual UCommerceDefinition Definition { get; set; }
        public virtual ICollection<UCommerceAward> UCommerceAward { get; set; }
        public virtual ICollection<UCommerceCampaignItemProperty> UCommerceCampaignItemProperty { get; set; }
        public virtual ICollection<UCommerceTarget> UCommerceTarget { get; set; }
    }
}
