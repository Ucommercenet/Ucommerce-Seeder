using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceAward
    {
        public int AwardId { get; set; }
        public int CampaignItemId { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCampaignItem CampaignItem { get; set; }
        public virtual UCommerceAmountOffOrderLinesAward UCommerceAmountOffOrderLinesAward { get; set; }
        public virtual UCommerceAmountOffOrderTotalAward UCommerceAmountOffOrderTotalAward { get; set; }
        public virtual UCommerceAmountOffUnitAward UCommerceAmountOffUnitAward { get; set; }
    }
}
