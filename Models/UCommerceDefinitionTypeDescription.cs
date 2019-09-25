using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDefinitionTypeDescription
    {
        public int DefinitionTypeDescriptionId { get; set; }
        public int DefinitionTypeId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string CultureCode { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDefinitionType DefinitionType { get; set; }
    }
}
