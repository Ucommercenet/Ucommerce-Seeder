using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceEntityProperty
    {
        public int EntityPropertyId { get; set; }
        public Guid EntityId { get; set; }
        public int DefinitionFieldId { get; set; }
        public string Value { get; set; }
        public int Version { get; set; }
        public string CultureCode { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDefinitionField DefinitionField { get; set; }
    }
}
