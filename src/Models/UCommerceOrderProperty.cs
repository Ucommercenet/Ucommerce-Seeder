using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceOrderProperty
    {
        public int OrderPropertyId { get; set; }
        public int OrderId { get; set; }
        public int? OrderLineId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePurchaseOrder Order { get; set; }
        public virtual UCommerceOrderLine OrderLine { get; set; }
    }
}
