using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsMemberType
    {
        public int Pk { get; set; }
        public int NodeId { get; set; }
        public int PropertytypeId { get; set; }
        public bool? MemberCanEdit { get; set; }
        public bool? ViewOnProfile { get; set; }
        public bool? IsSensitive { get; set; }

        public virtual UmbracoNode Node { get; set; }
        public virtual CmsContentType NodeNavigation { get; set; }
    }
}
