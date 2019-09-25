using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class CmsTags
    {
        public CmsTags()
        {
            CmsTagRelationship = new HashSet<CmsTagRelationship>();
        }

        public int Id { get; set; }
        public string Group { get; set; }
        public int? LanguageId { get; set; }
        public string Tag { get; set; }

        public virtual UmbracoLanguage Language { get; set; }
        public virtual ICollection<CmsTagRelationship> CmsTagRelationship { get; set; }
    }
}
