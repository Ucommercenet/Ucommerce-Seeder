using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceShippingMethodDescription
    {
        public int ShippingMethodDescriptionId { get; set; }
        public int ShippingMethodId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string DeliveryText { get; set; }
        public string CultureCode { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceShippingMethod ShippingMethod { get; set; }
    }
}
