using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoRelation
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public int RelType { get; set; }
        public DateTime Datetime { get; set; }
        public string Comment { get; set; }

        public virtual UmbracoNode Child { get; set; }
        public virtual UmbracoNode Parent { get; set; }
        public virtual UmbracoRelationType RelTypeNavigation { get; set; }
    }
}
