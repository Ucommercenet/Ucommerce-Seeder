using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDynamicOrderPropertyTarget
    {
        public int DynamicOrderPropertyTargetId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int CompareMode { get; set; }
        public bool TargetOrderLine { get; set; }
        public Guid Guid { get; set; }
    }
}
