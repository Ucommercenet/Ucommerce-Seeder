using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceOrderLineDiscountRelation
    {
        public int OrderLineDiscountRelationId { get; set; }
        public int DiscountId { get; set; }
        public int OrderLineId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDiscount Discount { get; set; }
        public virtual UCommerceOrderLine OrderLine { get; set; }
    }
}
