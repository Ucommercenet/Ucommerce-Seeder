using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceAmountOffOrderLinesAward
    {
        public int AmountOffOrderLinesAwardId { get; set; }
        public decimal AmountOff { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceAward AmountOffOrderLinesAward { get; set; }
    }
}
