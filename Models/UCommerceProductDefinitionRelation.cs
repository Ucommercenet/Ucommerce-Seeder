using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductDefinitionRelation
    {
        public int ProductDefinitionRelationId { get; set; }
        public int ProductDefinitionId { get; set; }
        public int ParentProductDefinitionId { get; set; }
        public int SortOrder { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceProductDefinition ParentProductDefinition { get; set; }
        public virtual UCommerceProductDefinition ProductDefinition { get; set; }
    }
}
