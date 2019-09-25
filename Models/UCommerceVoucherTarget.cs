using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceVoucherTarget
    {
        public UCommerceVoucherTarget()
        {
            UCommerceVoucherCode = new HashSet<UCommerceVoucherCode>();
        }

        public int VoucherTargetId { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceTarget VoucherTarget { get; set; }
        public virtual ICollection<UCommerceVoucherCode> UCommerceVoucherCode { get; set; }
    }
}
