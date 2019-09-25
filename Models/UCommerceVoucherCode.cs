using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceVoucherCode
    {
        public int VoucherCodeId { get; set; }
        public int TargetId { get; set; }
        public int NumberUsed { get; set; }
        public int MaxUses { get; set; }
        public string Code { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceVoucherTarget Target { get; set; }
    }
}
