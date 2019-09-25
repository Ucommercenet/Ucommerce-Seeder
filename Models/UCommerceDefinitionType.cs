using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDefinitionType
    {
        public UCommerceDefinitionType()
        {
            UCommerceDefinition = new HashSet<UCommerceDefinition>();
            UCommerceDefinitionTypeDescription = new HashSet<UCommerceDefinitionTypeDescription>();
        }

        public int DefinitionTypeId { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public int SortOrder { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceDefinition> UCommerceDefinition { get; set; }
        public virtual ICollection<UCommerceDefinitionTypeDescription> UCommerceDefinitionTypeDescription { get; set; }
    }
}
