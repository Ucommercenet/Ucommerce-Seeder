using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceUserWidgetSettingProperty
    {
        public int UserWidgetSettingPropertyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int? UserWidgetSettingId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceUserWidgetSetting UserWidgetSetting { get; set; }
    }
}
