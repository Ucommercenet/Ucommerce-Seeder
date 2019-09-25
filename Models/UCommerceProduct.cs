using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProduct
    {
        public UCommerceProduct()
        {
            InverseParentProduct = new HashSet<UCommerceProduct>();
            UCommerceCategoryProductRelation = new HashSet<UCommerceCategoryProductRelation>();
            UCommerceProductDescription = new HashSet<UCommerceProductDescription>();
            UCommerceProductPrice = new HashSet<UCommerceProductPrice>();
            UCommerceProductProperty = new HashSet<UCommerceProductProperty>();
            UCommerceProductRelationProduct = new HashSet<UCommerceProductRelation>();
            UCommerceProductRelationRelatedProduct = new HashSet<UCommerceProductRelation>();
            UCommerceProductReview = new HashSet<UCommerceProductReview>();
        }

        public int ProductId { get; set; }
        public int? ParentProductId { get; set; }
        public string Sku { get; set; }
        public string VariantSku { get; set; }
        public string Name { get; set; }
        public bool? DisplayOnSite { get; set; }
        public string ThumbnailImageMediaId { get; set; }
        public string PrimaryImageMediaId { get; set; }
        public decimal Weight { get; set; }
        public int ProductDefinitionId { get; set; }
        public bool? AllowOrdering { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public double? Rating { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceProduct ParentProduct { get; set; }
        public virtual UCommerceProductDefinition ProductDefinition { get; set; }
        public virtual ICollection<UCommerceProduct> InverseParentProduct { get; set; }
        public virtual ICollection<UCommerceCategoryProductRelation> UCommerceCategoryProductRelation { get; set; }
        public virtual ICollection<UCommerceProductDescription> UCommerceProductDescription { get; set; }
        public virtual ICollection<UCommerceProductPrice> UCommerceProductPrice { get; set; }
        public virtual ICollection<UCommerceProductProperty> UCommerceProductProperty { get; set; }
        public virtual ICollection<UCommerceProductRelation> UCommerceProductRelationProduct { get; set; }
        public virtual ICollection<UCommerceProductRelation> UCommerceProductRelationRelatedProduct { get; set; }
        public virtual ICollection<UCommerceProductReview> UCommerceProductReview { get; set; }
    }
}
