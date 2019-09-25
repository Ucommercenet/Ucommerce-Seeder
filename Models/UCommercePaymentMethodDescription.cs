using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePaymentMethodDescription
    {
        public int PaymentMethodDescriptionId { get; set; }
        public int PaymentMethodId { get; set; }
        public string CultureCode { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePaymentMethod PaymentMethod { get; set; }
    }
}
