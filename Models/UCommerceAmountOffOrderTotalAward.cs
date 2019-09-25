using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceAmountOffOrderTotalAward
    {
        public int AmountOffOrderTotalAwardId { get; set; }
        public decimal AmountOff { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceAward AmountOffOrderTotalAward { get; set; }
    }
}
