using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceQuantityTarget
    {
        public int QuantityTargetId { get; set; }
        public int MinQuantity { get; set; }
        public bool TargetOrderLine { get; set; }
        public Guid Guid { get; set; }
    }
}
