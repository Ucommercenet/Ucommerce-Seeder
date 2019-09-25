using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductCatalogGroupPaymentMethodMap
    {
        public int ProductCatalogGroupId { get; set; }
        public int PaymentMethodId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePaymentMethod PaymentMethod { get; set; }
        public virtual UCommerceProductCatalogGroup ProductCatalogGroup { get; set; }
    }
}
