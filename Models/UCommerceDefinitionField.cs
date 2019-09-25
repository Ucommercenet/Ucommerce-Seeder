using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UCommerceDefinitionField
    {
        public UCommerceDefinitionField()
        {
            UCommerceCampaignItemProperty = new HashSet<UCommerceCampaignItemProperty>();
            UCommerceCategoryProperty = new HashSet<UCommerceCategoryProperty>();
            UCommerceDefinitionFieldDescription = new HashSet<UCommerceDefinitionFieldDescription>();
            UCommerceEntityProperty = new HashSet<UCommerceEntityProperty>();
            UCommercePaymentMethodProperty = new HashSet<UCommercePaymentMethodProperty>();
        }

        public int DefinitionFieldId { get; set; }
        public int DataTypeId { get; set; }
        public int DefinitionId { get; set; }
        public string Name { get; set; }
        public bool DisplayOnSite { get; set; }
        public bool Multilingual { get; set; }
        public bool RenderInEditor { get; set; }
        public bool Searchable { get; set; }
        public int SortOrder { get; set; }
        public bool Deleted { get; set; }
        public bool BuiltIn { get; set; }
        public string DefaultValue { get; set; }
        public Guid Guid { get; set; }

        public virtual UCommerceDataType DataType { get; set; }
        public virtual UCommerceDefinition Definition { get; set; }
        public virtual ICollection<UCommerceCampaignItemProperty> UCommerceCampaignItemProperty { get; set; }
        public virtual ICollection<UCommerceCategoryProperty> UCommerceCategoryProperty { get; set; }
        public virtual ICollection<UCommerceDefinitionFieldDescription> UCommerceDefinitionFieldDescription { get; set; }
        public virtual ICollection<UCommerceEntityProperty> UCommerceEntityProperty { get; set; }
        public virtual ICollection<UCommercePaymentMethodProperty> UCommercePaymentMethodProperty { get; set; }
    }
}
