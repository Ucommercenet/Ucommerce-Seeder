using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePaymentProperty
    {
        public int PaymentPropertyId { get; set; }
        public int PaymentId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommercePayment Payment { get; set; }
    }
}
