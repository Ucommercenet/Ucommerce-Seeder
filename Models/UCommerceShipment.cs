using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceShipment
    {
        public UCommerceShipment()
        {
            UCommerceOrderLine = new HashSet<UCommerceOrderLine>();
            UCommerceShipmentDiscountRelation = new HashSet<UCommerceShipmentDiscountRelation>();
        }

        public int ShipmentId { get; set; }
        public string ShipmentName { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal ShipmentPrice { get; set; }
        public int ShippingMethodId { get; set; }
        public int? ShipmentAddressId { get; set; }
        public string DeliveryNote { get; set; }
        public int OrderId { get; set; }
        public string TrackAndTrace { get; set; }
        public string CreatedBy { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxRate { get; set; }
        public decimal ShipmentTotal { get; set; }
        public decimal? ShipmentDiscount { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePurchaseOrder Order { get; set; }
        public virtual UCommerceOrderAddress ShipmentAddress { get; set; }
        public virtual UCommerceShippingMethod ShippingMethod { get; set; }
        public virtual ICollection<UCommerceOrderLine> UCommerceOrderLine { get; set; }
        public virtual ICollection<UCommerceShipmentDiscountRelation> UCommerceShipmentDiscountRelation { get; set; }
    }
}
