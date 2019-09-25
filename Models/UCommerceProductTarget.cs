using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductTarget
    {
        public int ProductTargetId { get; set; }
        public string Skus { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceTarget ProductTarget { get; set; }
    }
}
