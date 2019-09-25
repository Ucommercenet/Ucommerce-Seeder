using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceEmailParameter
    {
        public UCommerceEmailParameter()
        {
            UCommerceEmailTypeParameter = new HashSet<UCommerceEmailTypeParameter>();
        }

        public int EmailParameterId { get; set; }
        public string Name { get; set; }
        public string GlobalResourceKey { get; set; }
        public string QueryStringKey { get; set; }
        public Guid Guid { get; set; }

        public virtual ICollection<UCommerceEmailTypeParameter> UCommerceEmailTypeParameter { get; set; }
    }
}
