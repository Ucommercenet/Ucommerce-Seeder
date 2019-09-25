using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductRelation
    {
        public int ProductRelationId { get; set; }
        public int ProductId { get; set; }
        public int RelatedProductId { get; set; }
        public int ProductRelationTypeId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceProduct Product { get; set; }
        public virtual UCommerceProductRelationType ProductRelationType { get; set; }
        public virtual UCommerceProduct RelatedProduct { get; set; }
    }
}
