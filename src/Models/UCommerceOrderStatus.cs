using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceOrderStatus
    {
        public UCommerceOrderStatus()
        {
            InverseNextOrderStatus = new HashSet<UCommerceOrderStatus>();
            UCommerceOrderStatusAudit = new HashSet<UCommerceOrderStatusAudit>();
            UCommercePurchaseOrder = new HashSet<UCommercePurchaseOrder>();
        }

        public int OrderStatusId { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
        public bool RenderChildren { get; set; }
        public bool? RenderInMenu { get; set; }
        public int? NextOrderStatusId { get; set; }
        public string ExternalId { get; set; }
        public bool? IncludeInAuditTrail { get; set; }
        public bool? AllowUpdate { get; set; }
        public bool AlwaysAvailable { get; set; }
        public string Pipeline { get; set; }
        public bool AllowOrderEdit { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceOrderStatus NextOrderStatus { get; set; }
        public virtual ICollection<UCommerceOrderStatus> InverseNextOrderStatus { get; set; }
        public virtual ICollection<UCommerceOrderStatusAudit> UCommerceOrderStatusAudit { get; set; }
        public virtual ICollection<UCommercePurchaseOrder> UCommercePurchaseOrder { get; set; }
    }
}
