using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoContentVersionCultureVariation
    {
        public int Id { get; set; }
        public int VersionId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? AvailableUserId { get; set; }

        public virtual UmbracoUser AvailableUser { get; set; }
        public virtual UmbracoLanguage Language { get; set; }
        public virtual UmbracoContentVersion Version { get; set; }
    }
}
