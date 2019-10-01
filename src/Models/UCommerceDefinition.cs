using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDefinition
    {
        public UCommerceDefinition()
        {
            UCommerceCampaignItem = new HashSet<UCommerceCampaignItem>();
            UCommerceCategory = new HashSet<UCommerceCategory>();
            UCommerceDataType = new HashSet<UCommerceDataType>();
            UCommerceDefinitionField = new HashSet<UCommerceDefinitionField>();
            UCommercePaymentMethod = new HashSet<UCommercePaymentMethod>();
            UCommerceProductCatalog = new HashSet<UCommerceProductCatalog>();
            UCommerceProductCatalogGroup = new HashSet<UCommerceProductCatalogGroup>();
        }

        public int DefinitionId { get; set; }
        public string Name { get; set; }
        public int DefinitionTypeId { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public int SortOrder { get; set; }
        public Guid Guid { get; set; }
        public bool BuiltIn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual UCommerceDefinitionType DefinitionType { get; set; }
        public virtual ICollection<UCommerceCampaignItem> UCommerceCampaignItem { get; set; }
        public virtual ICollection<UCommerceCategory> UCommerceCategory { get; set; }
        public virtual ICollection<UCommerceDataType> UCommerceDataType { get; set; }
        public virtual ICollection<UCommerceDefinitionField> UCommerceDefinitionField { get; set; }
        public virtual ICollection<UCommercePaymentMethod> UCommercePaymentMethod { get; set; }
        public virtual ICollection<UCommerceProductCatalog> UCommerceProductCatalog { get; set; }
        public virtual ICollection<UCommerceProductCatalogGroup> UCommerceProductCatalogGroup { get; set; }
    }
}
