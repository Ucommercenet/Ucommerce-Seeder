using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDefinitionRelation
    {
        public int DefinitionRelationId { get; set; }
        public int DefinitionId { get; set; }
        public int ParentDefinitionId { get; set; }
        public int SortOrder { get; set; }
        public Guid Guid { get; set; }
    }
}
