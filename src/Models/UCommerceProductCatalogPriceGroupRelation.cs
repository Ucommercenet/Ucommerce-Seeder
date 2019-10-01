using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductCatalogPriceGroupRelation
    {
        public int ProductCatalogPriceGroupRelationId { get; set; }
        public int ProductCatalogId { get; set; }
        public int PriceGroupId { get; set; }
        public int SortOrder { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePriceGroup PriceGroup { get; set; }
        public virtual UCommerceProductCatalog ProductCatalog { get; set; }
    }
}
