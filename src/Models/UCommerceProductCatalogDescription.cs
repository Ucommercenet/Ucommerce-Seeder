using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductCatalogDescription
    {
        public int ProductCatalogDescriptionId { get; set; }
        public int ProductCatalogId { get; set; }
        public string CultureCode { get; set; }
        public string DisplayName { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceProductCatalog ProductCatalog { get; set; }
    }
}
