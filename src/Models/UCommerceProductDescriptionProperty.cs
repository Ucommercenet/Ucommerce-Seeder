using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductDescriptionProperty
    {
        public int ProductDescriptionPropertyId { get; set; }
        public int ProductDescriptionId { get; set; }
        public int ProductDefinitionFieldId { get; set; }
        public string Value { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceProductDefinitionField ProductDefinitionField { get; set; }
        public virtual UCommerceProductDescription ProductDescription { get; set; }
    }
}
