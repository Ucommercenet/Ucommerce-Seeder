using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCampaignItemProperty
    {
        public int CampaignItemPropertyId { get; set; }
        public string Value { get; set; }
        public int DefinitionFieldId { get; set; }
        public string CultureCode { get; set; }
        public int CampaignItemId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCampaignItem CampaignItem { get; set; }
        public virtual UCommerceDefinitionField DefinitionField { get; set; }
    }
}
