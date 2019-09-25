using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductCatalogGroup
    {
        public UCommerceProductCatalogGroup()
        {
            UCommerceProductCatalog = new HashSet<UCommerceProductCatalog>();
            UCommerceProductCatalogGroupCampaignRelation = new HashSet<UCommerceProductCatalogGroupCampaignRelation>();
            UCommerceProductCatalogGroupPaymentMethodMap = new HashSet<UCommerceProductCatalogGroupPaymentMethodMap>();
            UCommerceProductCatalogGroupShippingMethodMap = new HashSet<UCommerceProductCatalogGroupShippingMethodMap>();
            UCommerceProductReview = new HashSet<UCommerceProductReview>();
            UCommercePurchaseOrder = new HashSet<UCommercePurchaseOrder>();
            UCommerceRole = new HashSet<UCommerceRole>();
        }

        public int ProductCatalogGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EmailProfileId { get; set; }
        public int CurrencyId { get; set; }
        public string DomainId { get; set; }
        public int? OrderNumberId { get; set; }
        public bool Deleted { get; set; }
        public bool CreateCustomersAsMembers { get; set; }
        public string MemberGroupId { get; set; }
        public string MemberTypeId { get; set; }
        public bool ProductReviewsRequireApproval { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int? DefinitionId { get; set; }

        public virtual UCommerceCurrency Currency { get; set; }
        public virtual UCommerceDefinition Definition { get; set; }
        public virtual UCommerceEmailProfile EmailProfile { get; set; }
        public virtual UCommerceOrderNumberSerie OrderNumber { get; set; }
        public virtual ICollection<UCommerceProductCatalog> UCommerceProductCatalog { get; set; }
        public virtual ICollection<UCommerceProductCatalogGroupCampaignRelation> UCommerceProductCatalogGroupCampaignRelation { get; set; }
        public virtual ICollection<UCommerceProductCatalogGroupPaymentMethodMap> UCommerceProductCatalogGroupPaymentMethodMap { get; set; }
        public virtual ICollection<UCommerceProductCatalogGroupShippingMethodMap> UCommerceProductCatalogGroupShippingMethodMap { get; set; }
        public virtual ICollection<UCommerceProductReview> UCommerceProductReview { get; set; }
        public virtual ICollection<UCommercePurchaseOrder> UCommercePurchaseOrder { get; set; }
        public virtual ICollection<UCommerceRole> UCommerceRole { get; set; }
    }
}
