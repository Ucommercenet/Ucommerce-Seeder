using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePaymentMethodCountry
    {
        public int PaymentMethodId { get; set; }
        public int CountryId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCountry Country { get; set; }
        public virtual UCommercePaymentMethod PaymentMethod { get; set; }
    }
}
