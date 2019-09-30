using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsTagRelationship
    {
        public int NodeId { get; set; }
        public int TagId { get; set; }
        public int PropertyTypeId { get; set; }

        public virtual UmbracoContent Node { get; set; }
        public virtual CmsPropertyType PropertyType { get; set; }
        public virtual CmsTags Tag { get; set; }
    }
}
