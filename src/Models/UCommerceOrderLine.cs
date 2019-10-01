using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceOrderLine
    {
        public UCommerceOrderLine()
        {
            UCommerceOrderLineDiscountRelation = new HashSet<UCommerceOrderLineDiscountRelation>();
            UCommerceOrderProperty = new HashSet<UCommerceOrderProperty>();
        }

        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public decimal? Total { get; set; }
        public decimal Vatrate { get; set; }
        public string VariantSku { get; set; }
        public int? ShipmentId { get; set; }
        public decimal? UnitDiscount { get; set; }
        public string CreatedBy { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePurchaseOrder Order { get; set; }
        public virtual UCommerceShipment Shipment { get; set; }
        public virtual ICollection<UCommerceOrderLineDiscountRelation> UCommerceOrderLineDiscountRelation { get; set; }
        public virtual ICollection<UCommerceOrderProperty> UCommerceOrderProperty { get; set; }
    }
}
