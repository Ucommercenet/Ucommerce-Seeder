using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoDocumentVersion
    {
        public int Id { get; set; }
        public int? TemplateId { get; set; }
        public bool Published { get; set; }

        public virtual UmbracoContentVersion IdNavigation { get; set; }
        public virtual CmsTemplate Template { get; set; }
    }
}
