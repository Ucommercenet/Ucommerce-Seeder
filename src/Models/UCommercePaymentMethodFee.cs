using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePaymentMethodFee
    {
        public int PaymentMethodFeeId { get; set; }
        public int PaymentMethodId { get; set; }
        public int PriceGroupId { get; set; }
        public decimal Fee { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePaymentMethod PaymentMethod { get; set; }
        public virtual UCommercePriceGroup PriceGroup { get; set; }
    }
}
