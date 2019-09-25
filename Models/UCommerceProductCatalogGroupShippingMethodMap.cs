using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductCatalogGroupShippingMethodMap
    {
        public int ProductCatalogGroupId { get; set; }
        public int ShippingMethodId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceProductCatalogGroup ProductCatalogGroup { get; set; }
        public virtual UCommerceShippingMethod ShippingMethod { get; set; }
    }
}
