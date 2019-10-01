using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoContentVersion
    {
        public UmbracoContentVersion()
        {
            UmbracoContentVersionCultureVariation = new HashSet<UmbracoContentVersionCultureVariation>();
            UmbracoPropertyData = new HashSet<UmbracoPropertyData>();
        }

        public int Id { get; set; }
        public int NodeId { get; set; }
        public DateTime VersionDate { get; set; }
        public int? UserId { get; set; }
        public bool Current { get; set; }
        public string Text { get; set; }

        public virtual UmbracoContent Node { get; set; }
        public virtual UmbracoUser User { get; set; }
        public virtual UmbracoDocumentVersion UmbracoDocumentVersion { get; set; }
        public virtual UmbracoMediaVersion UmbracoMediaVersion { get; set; }
        public virtual ICollection<UmbracoContentVersionCultureVariation> UmbracoContentVersionCultureVariation { get; set; }
        public virtual ICollection<UmbracoPropertyData> UmbracoPropertyData { get; set; }
    }
}
