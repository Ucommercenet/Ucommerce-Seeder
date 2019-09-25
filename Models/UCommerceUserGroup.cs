using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceUserGroup
    {
        public UCommerceUserGroup()
        {
            UCommerceUserGroupPermission = new HashSet<UCommerceUserGroupPermission>();
        }

        public int UserGroupId { get; set; }
        public string ExternalId { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceUserGroupPermission> UCommerceUserGroupPermission { get; set; }
    }
}
