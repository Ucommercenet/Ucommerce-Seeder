using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceShippingMethodPaymentMethods
    {
        public int ShippingMethodId { get; set; }
        public int PaymentMethodId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePaymentMethod PaymentMethod { get; set; }
        public virtual UCommerceShippingMethod ShippingMethod { get; set; }
    }
}
