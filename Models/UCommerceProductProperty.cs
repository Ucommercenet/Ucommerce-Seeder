using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductProperty
    {
        public int ProductPropertyId { get; set; }
        public string Value { get; set; }
        public int ProductDefinitionFieldId { get; set; }
        public int ProductId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceProduct Product { get; set; }
        public virtual UCommerceProductDefinitionField ProductDefinitionField { get; set; }
    }
}
