using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceFreeGiftAward
    {
        public int FreeGiftAwardId { get; set; }
        public string Sku { get; set; }
        public string VariantSku { get; set; }
        public Guid Guid { get; set; }
    }
}
