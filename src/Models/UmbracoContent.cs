using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoContent
    {
        public UmbracoContent()
        {
            CmsContentNu = new HashSet<CmsContentNu>();
            CmsTagRelationship = new HashSet<CmsTagRelationship>();
            UmbracoContentSchedule = new HashSet<UmbracoContentSchedule>();
            UmbracoContentVersion = new HashSet<UmbracoContentVersion>();
        }

        public int NodeId { get; set; }
        public int ContentTypeId { get; set; }

        public virtual CmsContentType ContentType { get; set; }
        public virtual UmbracoNode Node { get; set; }
        public virtual CmsMember CmsMember { get; set; }
        public virtual UmbracoDocument UmbracoDocument { get; set; }
        public virtual ICollection<CmsContentNu> CmsContentNu { get; set; }
        public virtual ICollection<CmsTagRelationship> CmsTagRelationship { get; set; }
        public virtual ICollection<UmbracoContentSchedule> UmbracoContentSchedule { get; set; }
        public virtual ICollection<UmbracoContentVersion> UmbracoContentVersion { get; set; }
    }
}
