using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDataTypeEnumDescription
    {
        public int DataTypeEnumDescriptionId { get; set; }
        public int DataTypeEnumId { get; set; }
        public string CultureCode { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDataTypeEnum DataTypeEnum { get; set; }
    }
}
