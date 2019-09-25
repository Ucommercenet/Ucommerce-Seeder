using System;
using System.Collections.Generic;

namespace Ucommerce.Seeder.Models
{
    public partial class UmbracoConsent
    {
        public int Id { get; set; }
        public bool Current { get; set; }
        public string Source { get; set; }
        public string Context { get; set; }
        public string Action { get; set; }
        public DateTime CreateDate { get; set; }
        public int State { get; set; }
        public string Comment { get; set; }
    }
}
