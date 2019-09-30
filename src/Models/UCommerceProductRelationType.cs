using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductRelationType
    {
        public UCommerceProductRelationType()
        {
            UCommerceProductRelation = new HashSet<UCommerceProductRelation>();
        }

        public int ProductRelationTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceProductRelation> UCommerceProductRelation { get; set; }
    }
}
