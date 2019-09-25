using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCategoryTarget
    {
        public int CategoryTargetId { get; set; }
        public string Name { get; set; }
        public string CategoryGuids { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceTarget CategoryTarget { get; set; }
    }
}
