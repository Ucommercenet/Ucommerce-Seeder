using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceTarget
    {
        public int TargetId { get; set; }
        public int CampaignItemId { get; set; }
        public bool EnabledForDisplay { get; set; }
        public bool EnabledForApply { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCampaignItem CampaignItem { get; set; }
        public virtual UCommerceCategoryTarget UCommerceCategoryTarget { get; set; }
        public virtual UCommerceProductCatalogTarget UCommerceProductCatalogTarget { get; set; }
        public virtual UCommerceProductTarget UCommerceProductTarget { get; set; }
        public virtual UCommerceVoucherTarget UCommerceVoucherTarget { get; set; }
    }
}
