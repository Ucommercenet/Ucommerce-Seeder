using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePriceGroupTarget
    {
        public int PriceGroupTargetId { get; set; }
        public string PriceGroupName { get; set; }
        public Guid Guid { get; set; }
    }
}
