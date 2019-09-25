using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDataType
    {
        public UCommerceDataType()
        {
            UCommerceDataTypeEnum = new HashSet<UCommerceDataTypeEnum>();
            UCommerceDefinitionField = new HashSet<UCommerceDefinitionField>();
            UCommerceProductDefinitionField = new HashSet<UCommerceProductDefinitionField>();
        }

        public int DataTypeId { get; set; }
        public string TypeName { get; set; }
        public bool Nullable { get; set; }
        public string ValidationExpression { get; set; }
        public bool BuiltIn { get; set; }
        public string DefinitionName { get; set; }
        public bool Deleted { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int? DefinitionId { get; set; }

        public virtual UCommerceDefinition Definition { get; set; }
        public virtual ICollection<UCommerceDataTypeEnum> UCommerceDataTypeEnum { get; set; }
        public virtual ICollection<UCommerceDefinitionField> UCommerceDefinitionField { get; set; }
        public virtual ICollection<UCommerceProductDefinitionField> UCommerceProductDefinitionField { get; set; }
    }
}
