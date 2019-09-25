using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsContentType
    {
        public CmsContentType()
        {
            CmsContentTypeAllowedContentTypeAllowed = new HashSet<CmsContentTypeAllowedContentType>();
            CmsContentTypeAllowedContentTypeIdNavigation = new HashSet<CmsContentTypeAllowedContentType>();
            CmsDocumentType = new HashSet<CmsDocumentType>();
            CmsMemberType = new HashSet<CmsMemberType>();
            CmsPropertyType = new HashSet<CmsPropertyType>();
            CmsPropertyTypeGroup = new HashSet<CmsPropertyTypeGroup>();
            UmbracoContent = new HashSet<UmbracoContent>();
        }

        public int Pk { get; set; }
        public int NodeId { get; set; }
        public string Alias { get; set; }
        public string Icon { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public bool? IsContainer { get; set; }
        public bool? IsElement { get; set; }
        public bool? AllowAtRoot { get; set; }
        public int Variations { get; set; }

        public virtual UmbracoNode Node { get; set; }
        public virtual ICollection<CmsContentTypeAllowedContentType> CmsContentTypeAllowedContentTypeAllowed { get; set; }
        public virtual ICollection<CmsContentTypeAllowedContentType> CmsContentTypeAllowedContentTypeIdNavigation { get; set; }
        public virtual ICollection<CmsDocumentType> CmsDocumentType { get; set; }
        public virtual ICollection<CmsMemberType> CmsMemberType { get; set; }
        public virtual ICollection<CmsPropertyType> CmsPropertyType { get; set; }
        public virtual ICollection<CmsPropertyTypeGroup> CmsPropertyTypeGroup { get; set; }
        public virtual ICollection<UmbracoContent> UmbracoContent { get; set; }
    }
}
