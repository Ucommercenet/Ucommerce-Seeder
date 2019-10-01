using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCampaign
    {
        public UCommerceCampaign()
        {
            UCommerceCampaignItem = new HashSet<UCommerceCampaignItem>();
            UCommerceProductCatalogGroupCampaignRelation = new HashSet<UCommerceProductCatalogGroupCampaignRelation>();
        }

        public int CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
        public bool Enabled { get; set; }
        public int? Priority { get; set; }
        public bool Deleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceCampaignItem> UCommerceCampaignItem { get; set; }
        public virtual ICollection<UCommerceProductCatalogGroupCampaignRelation> UCommerceProductCatalogGroupCampaignRelation { get; set; }
    }
}
