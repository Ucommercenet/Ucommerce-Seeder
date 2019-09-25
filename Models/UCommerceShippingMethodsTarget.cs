using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceShippingMethodsTarget
    {
        public int ShippingMethodsTargetId { get; set; }
        public string ShippingMethodsIdsList { get; set; }
        public Guid Guid { get; set; }
    }
}
