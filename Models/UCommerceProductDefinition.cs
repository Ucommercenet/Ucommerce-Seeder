using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductDefinition
    {
        public UCommerceProductDefinition()
        {
            UCommerceProduct = new HashSet<UCommerceProduct>();
            UCommerceProductDefinitionField = new HashSet<UCommerceProductDefinitionField>();
            UCommerceProductDefinitionRelationParentProductDefinition = new HashSet<UCommerceProductDefinitionRelation>();
            UCommerceProductDefinitionRelationProductDefinition = new HashSet<UCommerceProductDefinitionRelation>();
        }

        public int ProductDefinitionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }
        public int SortOrder { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<UCommerceProduct> UCommerceProduct { get; set; }
        public virtual ICollection<UCommerceProductDefinitionField> UCommerceProductDefinitionField { get; set; }
        public virtual ICollection<UCommerceProductDefinitionRelation> UCommerceProductDefinitionRelationParentProductDefinition { get; set; }
        public virtual ICollection<UCommerceProductDefinitionRelation> UCommerceProductDefinitionRelationProductDefinition { get; set; }
    }
}
