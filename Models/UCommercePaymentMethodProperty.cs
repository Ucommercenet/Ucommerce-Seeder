using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePaymentMethodProperty
    {
        public int PaymentMethodPropertyId { get; set; }
        public int DefinitionFieldId { get; set; }
        public string Value { get; set; }
        public string CultureCode { get; set; }
        public int PaymentMethodId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDefinitionField DefinitionField { get; set; }
        public virtual UCommercePaymentMethod PaymentMethod { get; set; }
    }
}
