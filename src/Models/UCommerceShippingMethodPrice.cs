using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceShippingMethodPrice
    {
        public int ShippingMethodPriceId { get; set; }
        public int ShippingMethodId { get; set; }
        public int PriceGroupId { get; set; }
        public decimal Price { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePriceGroup PriceGroup { get; set; }
        public virtual UCommerceShippingMethod ShippingMethod { get; set; }
    }
}
