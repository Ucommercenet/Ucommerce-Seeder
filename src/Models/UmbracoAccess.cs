using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoAccess
    {
        public UmbracoAccess()
        {
            UmbracoAccessRule = new HashSet<UmbracoAccessRule>();
        }

        public Guid Id { get; set; }
        public int NodeId { get; set; }
        public int LoginNodeId { get; set; }
        public int NoAccessNodeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual UmbracoNode LoginNode { get; set; }
        public virtual UmbracoNode NoAccessNode { get; set; }
        public virtual UmbracoNode Node { get; set; }
        public virtual ICollection<UmbracoAccessRule> UmbracoAccessRule { get; set; }
    }
}
