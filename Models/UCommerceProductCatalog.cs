using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductCatalog
    {
        public UCommerceProductCatalog()
        {
            UCommerceCategory = new HashSet<UCommerceCategory>();
            UCommerceProductCatalogDescription = new HashSet<UCommerceProductCatalogDescription>();
            UCommerceProductCatalogPriceGroupRelation = new HashSet<UCommerceProductCatalogPriceGroupRelation>();
            UCommerceRole = new HashSet<UCommerceRole>();
        }

        public int ProductCatalogId { get; set; }
        public int ProductCatalogGroupId { get; set; }
        public string Name { get; set; }
        public int PriceGroupId { get; set; }
        public bool? ShowPricesIncludingVat { get; set; }
        public bool DisplayOnWebSite { get; set; }
        public bool LimitedAccess { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int SortOrder { get; set; }
        public Guid Guid { get; set; }
        public int? DefinitionId { get; set; }

        public virtual UCommerceDefinition Definition { get; set; }
        public virtual UCommercePriceGroup PriceGroup { get; set; }
        public virtual UCommerceProductCatalogGroup ProductCatalogGroup { get; set; }
        public virtual ICollection<UCommerceCategory> UCommerceCategory { get; set; }
        public virtual ICollection<UCommerceProductCatalogDescription> UCommerceProductCatalogDescription { get; set; }
        public virtual ICollection<UCommerceProductCatalogPriceGroupRelation> UCommerceProductCatalogPriceGroupRelation { get; set; }
        public virtual ICollection<UCommerceRole> UCommerceRole { get; set; }
    }
}
