using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsTemplate
    {
        public CmsTemplate()
        {
            CmsDocumentType = new HashSet<CmsDocumentType>();
            UmbracoDocumentVersion = new HashSet<UmbracoDocumentVersion>();
        }

        public int Pk { get; set; }
        public int NodeId { get; set; }
        public string Alias { get; set; }

        public virtual UmbracoNode Node { get; set; }
        public virtual ICollection<CmsDocumentType> CmsDocumentType { get; set; }
        public virtual ICollection<UmbracoDocumentVersion> UmbracoDocumentVersion { get; set; }
    }
}
