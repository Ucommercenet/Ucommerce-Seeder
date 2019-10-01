using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCountry
    {
        public UCommerceCountry()
        {
            UCommerceAddress = new HashSet<UCommerceAddress>();
            UCommerceOrderAddress = new HashSet<UCommerceOrderAddress>();
            UCommercePaymentMethodCountry = new HashSet<UCommercePaymentMethodCountry>();
            UCommerceShippingMethodCountry = new HashSet<UCommerceShippingMethodCountry>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceAddress> UCommerceAddress { get; set; }
        public virtual ICollection<UCommerceOrderAddress> UCommerceOrderAddress { get; set; }
        public virtual ICollection<UCommercePaymentMethodCountry> UCommercePaymentMethodCountry { get; set; }
        public virtual ICollection<UCommerceShippingMethodCountry> UCommerceShippingMethodCountry { get; set; }
    }
}
