using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePriceGroup
    {
        public UCommercePriceGroup()
        {
            UCommercePaymentMethodFee = new HashSet<UCommercePaymentMethodFee>();
            UCommercePrice = new HashSet<UCommercePrice>();
            UCommerceProductCatalog = new HashSet<UCommerceProductCatalog>();
            UCommerceProductCatalogPriceGroupRelation = new HashSet<UCommerceProductCatalogPriceGroupRelation>();
            UCommerceRole = new HashSet<UCommerceRole>();
            UCommerceShippingMethodPrice = new HashSet<UCommerceShippingMethodPrice>();
        }

        public int PriceGroupId { get; set; }
        public string Name { get; set; }
        public int CurrencyId { get; set; }
        public decimal Vatrate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCurrency Currency { get; set; }
        public virtual ICollection<UCommercePaymentMethodFee> UCommercePaymentMethodFee { get; set; }
        public virtual ICollection<UCommercePrice> UCommercePrice { get; set; }
        public virtual ICollection<UCommerceProductCatalog> UCommerceProductCatalog { get; set; }
        public virtual ICollection<UCommerceProductCatalogPriceGroupRelation> UCommerceProductCatalogPriceGroupRelation { get; set; }
        public virtual ICollection<UCommerceRole> UCommerceRole { get; set; }
        public virtual ICollection<UCommerceShippingMethodPrice> UCommerceShippingMethodPrice { get; set; }
    }
}
