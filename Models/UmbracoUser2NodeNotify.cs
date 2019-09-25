using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoUser2NodeNotify
    {
        public int UserId { get; set; }
        public int NodeId { get; set; }
        public string Action { get; set; }

        public virtual UmbracoNode Node { get; set; }
        public virtual UmbracoUser User { get; set; }
    }
}
