using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductCatalogTarget
    {
        public int ProductCatalogTargetId { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceTarget ProductCatalogTarget { get; set; }
    }
}
