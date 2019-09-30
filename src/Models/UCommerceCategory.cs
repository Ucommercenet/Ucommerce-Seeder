using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCategory
    {
        public UCommerceCategory()
        {
            InverseParentCategory = new HashSet<UCommerceCategory>();
            UCommerceCategoryDescription = new HashSet<UCommerceCategoryDescription>();
            UCommerceCategoryProductRelation = new HashSet<UCommerceCategoryProductRelation>();
            UCommerceCategoryProperty = new HashSet<UCommerceCategoryProperty>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageMediaId { get; set; }
        public bool? DisplayOnSite { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ParentCategoryId { get; set; }
        public int ProductCatalogId { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public int SortOrder { get; set; }
        public string CreatedBy { get; set; }
        public int DefinitionId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDefinition Definition { get; set; }
        public virtual UCommerceCategory ParentCategory { get; set; }
        public virtual UCommerceProductCatalog ProductCatalog { get; set; }
        public virtual ICollection<UCommerceCategory> InverseParentCategory { get; set; }
        public virtual ICollection<UCommerceCategoryDescription> UCommerceCategoryDescription { get; set; }
        public virtual ICollection<UCommerceCategoryProductRelation> UCommerceCategoryProductRelation { get; set; }
        public virtual ICollection<UCommerceCategoryProperty> UCommerceCategoryProperty { get; set; }
    }
}
