using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceOrderNumberSerie
    {
        public UCommerceOrderNumberSerie()
        {
            UCommerceProductCatalogGroup = new HashSet<UCommerceProductCatalogGroup>();
        }

        public int OrderNumberId { get; set; }
        public string OrderNumberName { get; set; }
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public int Increment { get; set; }
        public int CurrentNumber { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceProductCatalogGroup> UCommerceProductCatalogGroup { get; set; }
    }
}
