using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceUserWidgetSetting
    {
        public UCommerceUserWidgetSetting()
        {
            UCommerceUserWidgetSettingProperty = new HashSet<UCommerceUserWidgetSettingProperty>();
        }

        public int UserWidgetSettingId { get; set; }
        public string Section { get; set; }
        public string WidgetName { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string PositionX { get; set; }
        public string PositionY { get; set; }
        public int? UserId { get; set; }
        public string DisplayName { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceUser User { get; set; }
        public virtual ICollection<UCommerceUserWidgetSettingProperty> UCommerceUserWidgetSettingProperty { get; set; }
    }
}
