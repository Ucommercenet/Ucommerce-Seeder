using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductPrice
    {
        public int ProductPriceId { get; set; }
        public int MinimumQuantity { get; set; }
        public Guid Guid { get; set; }
        public int ProductId { get; set; }
        public int PriceId { get; set; }

        public virtual UCommercePrice Price { get; set; }
        public virtual UCommerceProduct Product { get; set; }
    }
}
