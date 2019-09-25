using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceEmailTypeParameter
    {
        public int EmailTypeId { get; set; }
        public int EmailParameterId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceEmailParameter EmailParameter { get; set; }
        public virtual UCommerceEmailType EmailType { get; set; }
    }
}
