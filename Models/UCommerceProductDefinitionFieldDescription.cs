using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductDefinitionFieldDescription
    {
        public int ProductDefinitionFieldDescriptionId { get; set; }
        public string CultureCode { get; set; }
        public string DisplayName { get; set; }
        public int ProductDefinitionFieldId { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceProductDefinitionField ProductDefinitionField { get; set; }
    }
}
