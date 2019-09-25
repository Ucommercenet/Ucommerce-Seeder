using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceEntityUiDescription
    {
        public int EntityUiDescriptionId { get; set; }
        public int EntityUiId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string CultureCode { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceEntityUi EntityUi { get; set; }
    }
}
