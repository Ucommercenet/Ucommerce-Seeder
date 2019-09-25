using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDefinitionFieldDescription
    {
        public int DefinitionFieldDescriptionId { get; set; }
        public string CultureCode { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int DefinitionFieldId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDefinitionField DefinitionField { get; set; }
    }
}
