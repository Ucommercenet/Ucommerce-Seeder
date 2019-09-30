using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceUserGroupPermission
    {
        public int PermissionId { get; set; }
        public int? UserGroupId { get; set; }
        public int? RoleId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceRole Role { get; set; }
        public virtual UCommerceUserGroup UserGroup { get; set; }
    }
}
