using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePrice
    {
        public UCommercePrice()
        {
            UCommerceProductPrice = new HashSet<UCommerceProductPrice>();
        }

        public int PriceId { get; set; }
        public decimal Amount { get; set; }
        public int PriceGroupId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePriceGroup PriceGroup { get; set; }
        public virtual ICollection<UCommerceProductPrice> UCommerceProductPrice { get; set; }
    }
}
