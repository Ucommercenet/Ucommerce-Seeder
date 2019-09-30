using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePurchaseOrder
    {
        public UCommercePurchaseOrder()
        {
            UCommerceDiscount = new HashSet<UCommerceDiscount>();
            UCommerceOrderAddress = new HashSet<UCommerceOrderAddress>();
            UCommerceOrderLine = new HashSet<UCommerceOrderLine>();
            UCommerceOrderProperty = new HashSet<UCommerceOrderProperty>();
            UCommerceOrderStatusAudit = new HashSet<UCommerceOrderStatusAudit>();
            UCommercePayment = new HashSet<UCommercePayment>();
            UCommerceShipment = new HashSet<UCommerceShipment>();
        }

        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int? CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int CurrencyId { get; set; }
        public int ProductCatalogGroupId { get; set; }
        public int? BillingAddressId { get; set; }
        public string Note { get; set; }
        public Guid BasketId { get; set; }
        public decimal? Vat { get; set; }
        public decimal? OrderTotal { get; set; }
        public decimal? ShippingTotal { get; set; }
        public decimal? PaymentTotal { get; set; }
        public decimal? TaxTotal { get; set; }
        public decimal? SubTotal { get; set; }
        public Guid OrderGuid { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CultureCode { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscountTotal { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceOrderAddress BillingAddress { get; set; }
        public virtual UCommerceCurrency Currency { get; set; }
        public virtual UCommerceCustomer Customer { get; set; }
        public virtual UCommerceOrderStatus OrderStatus { get; set; }
        public virtual UCommerceProductCatalogGroup ProductCatalogGroup { get; set; }
        public virtual ICollection<UCommerceDiscount> UCommerceDiscount { get; set; }
        public virtual ICollection<UCommerceOrderAddress> UCommerceOrderAddress { get; set; }
        public virtual ICollection<UCommerceOrderLine> UCommerceOrderLine { get; set; }
        public virtual ICollection<UCommerceOrderProperty> UCommerceOrderProperty { get; set; }
        public virtual ICollection<UCommerceOrderStatusAudit> UCommerceOrderStatusAudit { get; set; }
        public virtual ICollection<UCommercePayment> UCommercePayment { get; set; }
        public virtual ICollection<UCommerceShipment> UCommerceShipment { get; set; }
    }
}
