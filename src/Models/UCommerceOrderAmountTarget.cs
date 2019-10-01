using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceOrderAmountTarget
    {
        public int OrderAmountTargetId { get; set; }
        public decimal MinAmount { get; set; }
        public Guid Guid { get; set; }
    }
}
