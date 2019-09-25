using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceOrderStatusAudit
    {
        public int OrderStatusAuditId { get; set; }
        public int NewOrderStatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public int OrderId { get; set; }
        public string Message { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceOrderStatus NewOrderStatus { get; set; }
        public virtual UCommercePurchaseOrder Order { get; set; }
    }
}
