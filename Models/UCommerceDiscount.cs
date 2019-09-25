using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDiscount
    {
        public UCommerceDiscount()
        {
            UCommerceOrderLineDiscountRelation = new HashSet<UCommerceOrderLineDiscountRelation>();
            UCommerceShipmentDiscountRelation = new HashSet<UCommerceShipmentDiscountRelation>();
        }

        public int DiscountId { get; set; }
        public int OrderId { get; set; }
        public string CampaignName { get; set; }
        public string CampaignItemName { get; set; }
        public string Description { get; set; }
        public decimal AmountOffTotal { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePurchaseOrder Order { get; set; }
        public virtual ICollection<UCommerceOrderLineDiscountRelation> UCommerceOrderLineDiscountRelation { get; set; }
        public virtual ICollection<UCommerceShipmentDiscountRelation> UCommerceShipmentDiscountRelation { get; set; }
    }
}
