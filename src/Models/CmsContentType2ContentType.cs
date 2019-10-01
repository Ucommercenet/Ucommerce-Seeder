using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsContentType2ContentType
    {
        public int ParentContentTypeId { get; set; }
        public int ChildContentTypeId { get; set; }

        public virtual UmbracoNode ChildContentType { get; set; }
        public virtual UmbracoNode ParentContentType { get; set; }
    }
}
