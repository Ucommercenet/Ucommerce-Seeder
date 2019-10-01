using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceUser
    {
        public UCommerceUser()
        {
            UCommercePermission = new HashSet<UCommercePermission>();
            UCommerceUserWidgetSetting = new HashSet<UCommerceUserWidgetSetting>();
        }

        public int UserId { get; set; }
        public string ExternalId { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommercePermission> UCommercePermission { get; set; }
        public virtual ICollection<UCommerceUserWidgetSetting> UCommerceUserWidgetSetting { get; set; }
    }
}
