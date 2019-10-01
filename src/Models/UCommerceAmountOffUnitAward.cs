using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceAmountOffUnitAward
    {
        public int AmountOffUnitAwardId { get; set; }
        public decimal AmountOff { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceAward AmountOffUnitAward { get; set; }
    }
}
