using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoRelationType
    {
        public UmbracoRelationType()
        {
            UmbracoRelation = new HashSet<UmbracoRelation>();
        }

        public int Id { get; set; }
        public Guid TypeUniqueId { get; set; }
        public bool Dual { get; set; }
        public Guid ParentObjectType { get; set; }
        public Guid ChildObjectType { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        public virtual ICollection<UmbracoRelation> UmbracoRelation { get; set; }
    }
}
