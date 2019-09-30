using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCategoryDescription
    {
        public int CategoryDescriptionId { get; set; }
        public int CategoryId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string CultureCode { get; set; }
        public bool RenderAsContent { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCategory Category { get; set; }
    }
}
