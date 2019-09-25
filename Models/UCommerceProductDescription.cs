using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductDescription
    {
        public UCommerceProductDescription()
        {
            UCommerceProductDescriptionProperty = new HashSet<UCommerceProductDescriptionProperty>();
        }

        public int ProductDescriptionId { get; set; }
        public int ProductId { get; set; }
        public string DisplayName { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string CultureCode { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceProduct Product { get; set; }
        public virtual ICollection<UCommerceProductDescriptionProperty> UCommerceProductDescriptionProperty { get; set; }
    }
}
