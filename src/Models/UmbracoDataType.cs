using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoDataType
    {
        public UmbracoDataType()
        {
            CmsPropertyType = new HashSet<CmsPropertyType>();
        }

        public int NodeId { get; set; }
        public string PropertyEditorAlias { get; set; }
        public string DbType { get; set; }
        public string Config { get; set; }

        public virtual UmbracoNode Node { get; set; }
        public virtual ICollection<CmsPropertyType> CmsPropertyType { get; set; }
    }
}
