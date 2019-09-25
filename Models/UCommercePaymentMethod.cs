using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePaymentMethod
    {
        public UCommercePaymentMethod()
        {
            UCommercePayment = new HashSet<UCommercePayment>();
            UCommercePaymentMethodCountry = new HashSet<UCommercePaymentMethodCountry>();
            UCommercePaymentMethodDescription = new HashSet<UCommercePaymentMethodDescription>();
            UCommercePaymentMethodFee = new HashSet<UCommercePaymentMethodFee>();
            UCommercePaymentMethodProperty = new HashSet<UCommercePaymentMethodProperty>();
            UCommerceProductCatalogGroupPaymentMethodMap = new HashSet<UCommerceProductCatalogGroupPaymentMethodMap>();
            UCommerceShippingMethod = new HashSet<UCommerceShippingMethod>();
            UCommerceShippingMethodPaymentMethods = new HashSet<UCommerceShippingMethodPaymentMethods>();
        }

        public int PaymentMethodId { get; set; }
        public string Name { get; set; }
        public decimal FeePercent { get; set; }
        public string ImageMediaId { get; set; }
        public string PaymentMethodServiceName { get; set; }
        public bool? Enabled { get; set; }
        public bool Deleted { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string Pipeline { get; set; }
        public int? DefinitionId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDefinition Definition { get; set; }
        public virtual ICollection<UCommercePayment> UCommercePayment { get; set; }
        public virtual ICollection<UCommercePaymentMethodCountry> UCommercePaymentMethodCountry { get; set; }
        public virtual ICollection<UCommercePaymentMethodDescription> UCommercePaymentMethodDescription { get; set; }
        public virtual ICollection<UCommercePaymentMethodFee> UCommercePaymentMethodFee { get; set; }
        public virtual ICollection<UCommercePaymentMethodProperty> UCommercePaymentMethodProperty { get; set; }
        public virtual ICollection<UCommerceProductCatalogGroupPaymentMethodMap> UCommerceProductCatalogGroupPaymentMethodMap { get; set; }
        public virtual ICollection<UCommerceShippingMethod> UCommerceShippingMethod { get; set; }
        public virtual ICollection<UCommerceShippingMethodPaymentMethods> UCommerceShippingMethodPaymentMethods { get; set; }
    }
}
