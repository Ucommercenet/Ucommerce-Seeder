using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceShippingMethodCountry
    {
        public int ShippingMethodId { get; set; }
        public int CountryId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCountry Country { get; set; }
        public virtual UCommerceShippingMethod ShippingMethod { get; set; }
    }
}
