using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductCatalogGroupCampaignRelation
    {
        public int ProductCatalogGroupCampaignRelationId { get; set; }
        public int? CampaignId { get; set; }
        public int? ProductCatalogGroupId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCampaign Campaign { get; set; }
        public virtual UCommerceProductCatalogGroup ProductCatalogGroup { get; set; }
    }
}
