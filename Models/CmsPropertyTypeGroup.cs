using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsPropertyTypeGroup
    {
        public CmsPropertyTypeGroup()
        {
            CmsPropertyType = new HashSet<CmsPropertyType>();
        }

        public int Id { get; set; }
        public int ContenttypeNodeId { get; set; }
        public string Text { get; set; }
        public int Sortorder { get; set; }
        public Guid UniqueId { get; set; }

        public virtual CmsContentType ContenttypeNode { get; set; }
        public virtual ICollection<CmsPropertyType> CmsPropertyType { get; set; }
    }
}
