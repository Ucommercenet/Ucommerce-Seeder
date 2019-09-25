using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceEntityUi
    {
        public UCommerceEntityUi()
        {
            UCommerceEntityUiDescription = new HashSet<UCommerceEntityUiDescription>();
        }

        public int EntityUiId { get; set; }
        public string Type { get; set; }
        public string VirtualPathUi { get; set; }
        public int SortOrder { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceEntityUiDescription> UCommerceEntityUiDescription { get; set; }
    }
}
