using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceShippingMethod
    {
        public UCommerceShippingMethod()
        {
            UCommerceProductCatalogGroupShippingMethodMap = new HashSet<UCommerceProductCatalogGroupShippingMethodMap>();
            UCommerceShipment = new HashSet<UCommerceShipment>();
            UCommerceShippingMethodCountry = new HashSet<UCommerceShippingMethodCountry>();
            UCommerceShippingMethodDescription = new HashSet<UCommerceShippingMethodDescription>();
            UCommerceShippingMethodPaymentMethods = new HashSet<UCommerceShippingMethodPaymentMethods>();
            UCommerceShippingMethodPrice = new HashSet<UCommerceShippingMethodPrice>();
        }

        public int ShippingMethodId { get; set; }
        public string Name { get; set; }
        public string ImageMediaId { get; set; }
        public int? PaymentMethodId { get; set; }
        public string ServiceName { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePaymentMethod PaymentMethod { get; set; }
        public virtual ICollection<UCommerceProductCatalogGroupShippingMethodMap> UCommerceProductCatalogGroupShippingMethodMap { get; set; }
        public virtual ICollection<UCommerceShipment> UCommerceShipment { get; set; }
        public virtual ICollection<UCommerceShippingMethodCountry> UCommerceShippingMethodCountry { get; set; }
        public virtual ICollection<UCommerceShippingMethodDescription> UCommerceShippingMethodDescription { get; set; }
        public virtual ICollection<UCommerceShippingMethodPaymentMethods> UCommerceShippingMethodPaymentMethods { get; set; }
        public virtual ICollection<UCommerceShippingMethodPrice> UCommerceShippingMethodPrice { get; set; }
    }
}
