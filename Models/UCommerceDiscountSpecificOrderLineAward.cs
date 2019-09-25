using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDiscountSpecificOrderLineAward
    {
        public int DiscountSpecificOrderLineAwardId { get; set; }
        public decimal AmountOff { get; set; }
        public int AmountType { get; set; }
        public int DiscountTarget { get; set; }
        public string Sku { get; set; }
        public string VariantSku { get; set; }
        public Guid Guid { get; set; }
    }
}
