using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCategoryProductRelation
    {
        public int CategoryProductRelationId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SortOrder { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCategory Category { get; set; }
        public virtual UCommerceProduct Product { get; set; }
    }
}
