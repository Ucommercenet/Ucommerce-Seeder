using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePercentOffOrderLinesAward
    {
        public int PercentOffOrderLinesAwardId { get; set; }
        public decimal PercentOff { get; set; }
        public Guid Guid { get; set; }
    }
}
