using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoRedirectUrl
    {
        public Guid Id { get; set; }
        public Guid ContentKey { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public string Url { get; set; }
        public string Culture { get; set; }
        public string UrlHash { get; set; }

        public virtual UmbracoNode ContentKeyNavigation { get; set; }
    }
}
