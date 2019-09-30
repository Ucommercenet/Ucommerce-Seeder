using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommercePermission
    {
        public int PermissionId { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceRole Role { get; set; }
        public virtual UCommerceUser User { get; set; }
    }
}
