using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsDocumentType
    {
        public int ContentTypeNodeId { get; set; }
        public int TemplateNodeId { get; set; }
        public bool? IsDefault { get; set; }

        public virtual UmbracoNode ContentTypeNode { get; set; }
        public virtual CmsContentType ContentTypeNodeNavigation { get; set; }
        public virtual CmsTemplate TemplateNode { get; set; }
    }
}
