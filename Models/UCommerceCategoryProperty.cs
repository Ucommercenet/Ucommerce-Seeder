using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceCategoryProperty
    {
        public int CategoryPropertyId { get; set; }
        public string Value { get; set; }
        public int DefinitionFieldId { get; set; }
        public string CultureCode { get; set; }
        public int CategoryId { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceCategory Category { get; set; }
        public virtual UCommerceDefinitionField DefinitionField { get; set; }
    }
}
