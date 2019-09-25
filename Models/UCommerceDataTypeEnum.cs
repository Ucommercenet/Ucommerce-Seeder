using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDataTypeEnum
    {
        public UCommerceDataTypeEnum()
        {
            UCommerceDataTypeEnumDescription = new HashSet<UCommerceDataTypeEnumDescription>();
        }

        public int DataTypeEnumId { get; set; }
        public int DataTypeId { get; set; }
        public string Value { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }
        public int SortOrder { get; set; }

        public virtual UCommerceDataType DataType { get; set; }
        public virtual ICollection<UCommerceDataTypeEnumDescription> UCommerceDataTypeEnumDescription { get; set; }
    }
}
