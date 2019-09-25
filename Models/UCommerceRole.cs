using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceRole
    {
        public UCommerceRole()
        {
            InverseParentRole = new HashSet<UCommerceRole>();
            UCommercePermission = new HashSet<UCommercePermission>();
            UCommerceUserGroupPermission = new HashSet<UCommerceUserGroupPermission>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public int? ProductCatalogGroupId { get; set; }
        public int? ProductCatalogId { get; set; }
        public string CultureCode { get; set; }
        public int? PriceGroupId { get; set; }
        public int RoleType { get; set; }
        public int? ParentRoleId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceRole ParentRole { get; set; }
        public virtual UCommercePriceGroup PriceGroup { get; set; }
        public virtual UCommerceProductCatalog ProductCatalog { get; set; }
        public virtual UCommerceProductCatalogGroup ProductCatalogGroup { get; set; }
        public virtual ICollection<UCommerceRole> InverseParentRole { get; set; }
        public virtual ICollection<UCommercePermission> UCommercePermission { get; set; }
        public virtual ICollection<UCommerceUserGroupPermission> UCommerceUserGroupPermission { get; set; }
    }
}
