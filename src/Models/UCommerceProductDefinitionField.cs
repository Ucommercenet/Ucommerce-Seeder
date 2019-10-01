using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceProductDefinitionField
    {
        public UCommerceProductDefinitionField()
        {
            UCommerceProductDefinitionFieldDescription = new HashSet<UCommerceProductDefinitionFieldDescription>();
            UCommerceProductDescriptionProperty = new HashSet<UCommerceProductDescriptionProperty>();
            UCommerceProductProperty = new HashSet<UCommerceProductProperty>();
        }

        public int ProductDefinitionFieldId { get; set; }
        public int DataTypeId { get; set; }
        public int ProductDefinitionId { get; set; }
        public string Name { get; set; }
        public bool DisplayOnSite { get; set; }
        public bool IsVariantProperty { get; set; }
        public bool Multilingual { get; set; }
        public bool RenderInEditor { get; set; }
        public bool Searchable { get; set; }
        public bool Deleted { get; set; }
        public int SortOrder { get; set; }
        public bool Facet { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDataType DataType { get; set; }
        public virtual UCommerceProductDefinition ProductDefinition { get; set; }
        public virtual ICollection<UCommerceProductDefinitionFieldDescription> UCommerceProductDefinitionFieldDescription { get; set; }
        public virtual ICollection<UCommerceProductDescriptionProperty> UCommerceProductDescriptionProperty { get; set; }
        public virtual ICollection<UCommerceProductProperty> UCommerceProductProperty { get; set; }
    }
}
