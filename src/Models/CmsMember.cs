using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsMember
    {
        public CmsMember()
        {
            CmsMember2MemberGroup = new HashSet<CmsMember2MemberGroup>();
        }

        public int NodeId { get; set; }
        public string Email { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }

        public virtual UmbracoContent Node { get; set; }
        public virtual ICollection<CmsMember2MemberGroup> CmsMember2MemberGroup { get; set; }
    }
}
