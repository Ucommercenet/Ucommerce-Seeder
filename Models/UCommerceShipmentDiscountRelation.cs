using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceShipmentDiscountRelation
    {
        public int ShipmentDiscountRelationId { get; set; }
        public int ShipmentId { get; set; }
        public int DiscountId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDiscount Discount { get; set; }
        public virtual UCommerceShipment Shipment { get; set; }
    }
}
