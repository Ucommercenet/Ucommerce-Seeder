using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePaymentStatus
    {
        public UCommercePaymentStatus()
        {
            UCommercePayment = new HashSet<UCommercePayment>();
        }

        public int PaymentStatusId { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommercePayment> UCommercePayment { get; set; }
    }
}
