using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoLanguage
    {
        public UmbracoLanguage()
        {
            CmsLanguageText = new HashSet<CmsLanguageText>();
            CmsTags = new HashSet<CmsTags>();
            InverseFallbackLanguage = new HashSet<UmbracoLanguage>();
            UmbracoContentSchedule = new HashSet<UmbracoContentSchedule>();
            UmbracoContentVersionCultureVariation = new HashSet<UmbracoContentVersionCultureVariation>();
            UmbracoDocumentCultureVariation = new HashSet<UmbracoDocumentCultureVariation>();
            UmbracoPropertyData = new HashSet<UmbracoPropertyData>();
        }

        public int Id { get; set; }
        public string LanguageIsocode { get; set; }
        public string LanguageCultureName { get; set; }
        public bool? IsDefaultVariantLang { get; set; }
        public bool? Mandatory { get; set; }
        public int? FallbackLanguageId { get; set; }

        public virtual UmbracoLanguage FallbackLanguage { get; set; }
        public virtual ICollection<CmsLanguageText> CmsLanguageText { get; set; }
        public virtual ICollection<CmsTags> CmsTags { get; set; }
        public virtual ICollection<UmbracoLanguage> InverseFallbackLanguage { get; set; }
        public virtual ICollection<UmbracoContentSchedule> UmbracoContentSchedule { get; set; }
        public virtual ICollection<UmbracoContentVersionCultureVariation> UmbracoContentVersionCultureVariation { get; set; }
        public virtual ICollection<UmbracoDocumentCultureVariation> UmbracoDocumentCultureVariation { get; set; }
        public virtual ICollection<UmbracoPropertyData> UmbracoPropertyData { get; set; }
    }
}
