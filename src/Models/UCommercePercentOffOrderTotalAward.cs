using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePercentOffOrderTotalAward
    {
        public int PercentOffOrderTotalAwardId { get; set; }
        public decimal PercentOff { get; set; }
        public Guid Guid { get; set; }
    }
}
